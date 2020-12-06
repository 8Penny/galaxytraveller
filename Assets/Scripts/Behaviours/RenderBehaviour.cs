using System;
using System.Collections.Generic;
using Core;
using Data;
using Data.PlayerStats;
using Interfaces;
using Managers;
using UnityEngine;

namespace Behaviours
{
    [CreateAssetMenu(fileName = "RenderBehaviour", menuName = "Behaviours/RenderBehaviour")]
    public class RenderBehaviour : BaseBehaviour, IAwake
    {
        public override IEnumerable<Type> GetDataTypeNeed()
        {
            var types = new List<Type>()
            {
                typeof(RBData)
            };
            return types;
        }

        public void OnAwake()
        {
            var statsMng = GameCore.Get<PlayerStatsManager>();
            _data.TryGetValue(typeof(RBData), out var d);

            var rData = (RBData)d;
            rData.rigidbody.position = statsMng.GetPosition();
            rData.rigidbody.rotation = Quaternion.Euler(new Vector3(0,statsMng.GetRotation(),0));
        }
    }
}