using System;
using System.Collections.Generic;
using Data;
using Interfaces;
using UnityEngine;

namespace Behaviours
{
    [CreateAssetMenu]
    public class PlayerInputBehaviour : BaseBehaviour, ITick
    {
        private PlayerInputData _playerInputData;
        public override IEnumerable<Type> GetDataTypeNeed()
        {
            var types = new List<Type>()
            {
                typeof(PlayerInputData),
            };
            return types;
        }

        public override void OnBehaviourEnable()
        {
            _data.TryGetValue(typeof(PlayerInputData), out var data);
            _playerInputData = (PlayerInputData) data;
        }
        public void Tick()
        {
            _playerInputData.horizontal = Input.GetAxisRaw("Horizontal");
            _playerInputData.vertical = Input.GetAxisRaw("Vertical");
        }
    }
}