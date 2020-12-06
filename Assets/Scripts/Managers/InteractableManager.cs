using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Data;
using Interfaces;
using UnityEngine;

namespace Managers {
    [CreateAssetMenu(fileName = "InteractableManager", menuName = "Managers/InteractableManager")]
    public class InteractableManager : BaseManager, ITick {
        [SerializeField] private PlanetData _planetData;
        [SerializeField] private GameObject _interactionLightPrefab;

        private PlayerStatsManager _playerStatsMng;
        private Tuple<InteractableData, RenderingData> _currentInteractableData;
        private GameObject _interactionLight;

        private List<Tuple<InteractableData, RenderingData>> _interactionObjects =
            new List<Tuple<InteractableData, RenderingData>>();

        private void Awake() {
            _playerStatsMng = GameCore.Get<PlayerStatsManager>();

            var parent = GameObject.FindWithTag(Tags.Location).transform;
            _interactionLight = Instantiate(_interactionLightPrefab, parent);
            _interactionLight.SetActive(false);
        }

        private void OnEnable() {
            UpdateManager.AddTo(this);
        }


        public void SetInteractable(InteractableData interactableData, RenderingData renderingData) {
            var tupleData = new Tuple<InteractableData, RenderingData>(interactableData, renderingData);
            _interactionObjects.Add(tupleData);

            if (!_interactionLight.activeSelf) {
                _interactionLight.SetActive(true);
            }
        }

        public void RemoveInteractable(InteractableData interactableData, RenderingData renderingData) {
            _interactionObjects.Remove(new Tuple<InteractableData, RenderingData>(interactableData, renderingData));
            if (_interactionObjects.Count != 0) {
                return;
            }

            _currentInteractableData = null;
            _interactionLight.SetActive(false);
        }

        public void Tick() {
            if (_interactionObjects.Count == 0) {
                return;
            }

            var playerPosition = _playerStatsMng.GetPosition();
            var distance = float.PositiveInfinity;
            var nextInteractableObject = _interactionObjects.First();
            foreach (var iObject in _interactionObjects) {
                var nextDistance = Vector3.Distance(iObject.Item2.transform.position, playerPosition);
                if (nextDistance < distance) {
                    distance = nextDistance;
                    nextInteractableObject = iObject;
                }
            }

            if (nextInteractableObject.Equals(_currentInteractableData)) {
                return;
            }

            _currentInteractableData = nextInteractableObject;

            _interactionLight.transform.position = _currentInteractableData.Item2.transform.position;
            _interactionLight.transform.LookAt(_planetData.position);
            _interactionLight.transform.Rotate(-90, 0, 0);
            var scale = _currentInteractableData.Item1.interactionLightScale;
            _interactionLight.transform.localScale = new Vector3(scale, scale, scale);
        }

        private void OnDisable() {
            UpdateManager.RemoveFrom(this);
        }
    }
}