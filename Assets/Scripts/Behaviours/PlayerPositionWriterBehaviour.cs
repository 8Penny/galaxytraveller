using System;
using System.Collections.Generic;
using Core;
using Data;
using Interfaces;
using Managers;
using UnityEngine;

namespace Behaviours
{
    [CreateAssetMenu(fileName = "PlayerPositionWriterBehaviour", menuName = "Behaviours/PlayerPositionWriterBehaviour")]
    public class PlayerPositionWriterBehaviour: BaseBehaviour, ITickLate
    {
        private RBData _rData;
        private PlayerStatsManager _playerStatsMng;
        public override IEnumerable<Type> GetDataTypeNeed()
        {
            var types = new List<Type>()
            {
                typeof(RBData)
            };
            return types;
        }

        public override void OnBehaviourEnable(){
            _playerStatsMng = GameCore.Get<PlayerStatsManager>();
            _data.TryGetValue(typeof(RBData), out var d);
            _rData = (RBData) d;
        }

        public void TickLate()
        {
            _playerStatsMng.SetPosition(_rData.rigidbody.position);
            _playerStatsMng.SetRotation(_rData.rigidbody.rotation.eulerAngles.y);
        }
    }
}