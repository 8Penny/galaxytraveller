using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Data;
using Interfaces;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Utils;

namespace Managers {
    [CreateAssetMenu(fileName = "InteractableManager", menuName = "Managers/InteractableManager")]
    public class InteractableManager : BaseManager, ITick {
        [SerializeField] private PlanetData _planetData;
        [SerializeField] private GameObject _interactionLightPrefab;
        [SerializeField] private GameObject _interactionProgressPrefab;

        public delegate void ChangeInteraction();
        public bool hasInteractable => _currentInteractableData != null;
        public InteractableType interactableType => _currentInteractableData?.iData.iType ?? InteractableType.Resource;
        
        private event ChangeInteraction InteractionChanged;
        
        private PlayerStatsManager _playerStatsMng;
        private InteractableContainer _currentInteractableData;
        private GameObject _interactionLight;
        private GameObject _interactionProgress;

        private List<InteractableContainer> _interactionObjects;

        public void Interact() {
            _currentInteractableData.iData.started = true;
            _interactionLight.TrySetActive(false);
            _interactionProgress.TrySetActive(true);
            UpdateEffectObjectPosition(_interactionProgress);
        }

        public void Tick() {
            if (_interactionObjects.Count == 0 || (_currentInteractableData?.iData.started ?? false)) {
                return;
            }

            var playerPosition = _playerStatsMng.GetPosition();
            var distance = float.PositiveInfinity;
            var nextInteractableObject = _interactionObjects.First();
            foreach (var iObject in _interactionObjects) {
                var nextDistance = Vector3.Distance(iObject.rData.transform.position, playerPosition);
                if (nextDistance < distance) {
                    distance = nextDistance;
                    nextInteractableObject = iObject;
                }
            }

            if (nextInteractableObject.Equals(_currentInteractableData)) {
                return;
            }

            _currentInteractableData = nextInteractableObject;
            UpdateEffectObjectPosition(_interactionLight);
            InteractionChanged?.Invoke();
        }

        public void SetInteractable(InteractableData interactableData, RenderingData renderingData) {
            var tupleData = new InteractableContainer(interactableData, renderingData);
            _interactionObjects.Add(tupleData);

            _interactionLight.TrySetActive(true);
        }

        public void RemoveInteractable(InteractableData interactableData) {
            var isCurrInteractionStarted = _currentInteractableData.iData.started;
            var isEqualsCurrent = _currentInteractableData.iData == interactableData;
            if (isCurrInteractionStarted && isEqualsCurrent) {
                _currentInteractableData.iData.started = false;
                _interactionProgress.TrySetActive(false);
            }
            
            var dataContainer = _interactionObjects.Find(s => s.iData == interactableData);
            _interactionObjects.Remove(dataContainer);
            if (_interactionObjects.Count != 0) {
                return;
            }

            _currentInteractableData = null;
            _interactionLight.TrySetActive(false);
            InteractionChanged?.Invoke();
        }

        public void Bind(ChangeInteraction function) {
            InteractionChanged += function;
        }

        public void Loose(ChangeInteraction function) {
            InteractionChanged -= function;
        }

        private void Awake() {
            _playerStatsMng = GameCore.Get<PlayerStatsManager>();
            _interactionObjects = new List<InteractableContainer>();

            var parent = GameObject.FindWithTag(Tags.Location).transform;
            _interactionLight = Instantiate(_interactionLightPrefab, parent);
            _interactionLight.TrySetActive(false);
            
            _interactionProgress = Instantiate(_interactionProgressPrefab, parent);
            _interactionProgress.TrySetActive(false);
        }

        private void OnEnable() {
            UpdateManager.AddTo(this);
        }
        
        private void OnDisable() {
            UpdateManager.RemoveFrom(this);
        }

        private void UpdateEffectObjectPosition(GameObject gameObject) {
            gameObject.transform.position = _currentInteractableData.rData.transform.position;
            gameObject.transform.LookAt(_planetData.position);
            gameObject.transform.Rotate(-90, 0, 0);
            var scale = _currentInteractableData.iData.interactionLightScale;
            gameObject.transform.localScale = new Vector3(scale, scale, scale);
        }
    }

    public class InteractableContainer {
        public RenderingData rData;
        public InteractableData iData;

        public InteractableContainer(InteractableData i, RenderingData r) {
            rData = r;
            iData = i;
        }
    }
}