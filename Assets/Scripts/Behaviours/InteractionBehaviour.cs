using System;
using System.Collections.Generic;
using Core;
using Data;
using Data.PlayerStats;
using Interfaces;
using Items;
using Managers;
using UnityEngine;

namespace Behaviours {
    [CreateAssetMenu(fileName = "InteractionBehaviour", menuName = "Behaviours/InteractionBehaviour")]
    public class InteractionBehaviour : BaseBehaviour, ITick {
        private float _timer;
        private bool _isStarted;
        private InteractableData _interactableData;
        private InteractableManager _interactableMng;
        public override IEnumerable<Type> GetDataTypeNeed() {
            var types = new List<Type>()
            {
                typeof(InteractableData),
                typeof(ItemData)
            };
            return types;
        }

        public override void OnBehaviourEnable() {
            _interactableMng = GameCore.Get<InteractableManager>();
            _interactableData = GetDataOfType<InteractableData>();
        }

        public void Tick() {
            if (_isStarted) {
                if (_interactableData.started == false) {
                    _isStarted = false;
                    return;
                }
                UpdateTimer();
                return;
            }

            if (!_isStarted && _interactableData.started) {
                _isStarted = true;
                _timer = _interactableData.interactionTime;
            }
        }

        private void UpdateTimer() {
            if (_timer > 0) {
                _timer -= Time.deltaTime;
                return;
            }

            _isStarted = false;

            var playerStatsMng = GameCore.Get<PlayerStatsManager>();
            var item = new ResourceItem(GetDataOfType<ItemData>());
            playerStatsMng.AddToInventory(item);
            _interactableData.CallOnFinished();
        }
    }
}