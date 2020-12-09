using System;
using System.Collections.Generic;
using Core;
using Data;
using Data.Spawner;
using Interfaces;
using Items;
using Managers;
using UnityEngine;

namespace Behaviours {
    [CreateAssetMenu(fileName = "ResourceSuccessInteractionBehaviour", menuName = "Behaviours/ResourceSuccessInteractionBehaviour")]
    public class ResourceSuccessInteractionBehaviour: BaseBehaviour, ITick{
        private InteractableData _interactableData;
        private SuccessInteractionData _successData;
        private RenderingData _renderingData;
        private SpawnData _spawnData;
        public override IEnumerable<Type> GetDataTypeNeed() {
            var types = new List<Type>()
            {
                typeof(InteractableData),
                typeof(ItemData),
                typeof(SuccessInteractionData),
                typeof(RenderingData),
                typeof(SpawnData)
            };
            return types;
        }

        public override void OnBehaviourEnable() {
            _interactableData = GetDataOfType<InteractableData>();
            _successData = GetDataOfType<SuccessInteractionData>();
            _renderingData = GetDataOfType<RenderingData>();
            _spawnData = GetDataOfType<SpawnData>();
        }


        public void Tick() {
            if (_successData.iSucceeded) {
                OnSuccess();
            }
        }

        private void OnSuccess() {
            var playerStatsMng = GameCore.Get<PlayerStatsManager>();
            var item = new ResourceItem(GetDataOfType<ItemData>());
            playerStatsMng.AddToInventory(item);
            var homeMng = GameCore.Get<HomeLocationManager>();
            homeMng.RemoveEnvironmentElement(_spawnData.id, _renderingData.transform.position);
            
            _interactableData.CallOnFinished();
            _successData.iSucceeded = false;
        }
    }
}