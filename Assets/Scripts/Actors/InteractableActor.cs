using System;
using Core;
using Data;
using Managers;
using UnityEngine;
using UnityEngine.TestTools;

namespace Actors {
    public class InteractableActor : Actor {
        protected InteractableManager _interactableMng;
        protected InteractableData _interactableData;
        private RenderingData _renderingData;

        protected override void AfterAwake() {
            _interactableMng = GameCore.Get<InteractableManager>();
            _interactableData = (InteractableData) GetData(typeof(InteractableData));
            _renderingData = (RenderingData) GetData(typeof(RenderingData));
            _renderingData.transform = gameObject.transform;

            _interactableData.interactionLightScale = gameObject.GetComponent<SphereCollider>().radius;
        }

        private void OnTriggerEnter(Collider other) {
            if (!other.CompareTag("Player")) {
                return;
            }

            _interactableMng.SetInteractable(_interactableData, _renderingData);
        }

        private void OnTriggerExit(Collider other) {
            if (!other.CompareTag("Player")) {
                return;
            }

            _interactableMng.RemoveInteractable(_interactableData);
        }
    }
}