using System;
using System.Collections.Generic;
using Data;
using Interfaces;
using UnityEngine;

namespace Behaviours
{
    [CreateAssetMenu(fileName = "GravityBehaviour", menuName = "Behaviours/GravityBehaviour")]
    public class GravityBehaviour : BaseBehaviour, ITickFixed
    {
        private RenderData _renderData;
        private EarthData _earthData;
        public override IEnumerable<Type> GetDataTypeNeed()
        {
            var types = new List<Type>()
            {
                typeof(RenderData),
                typeof(EarthData)
            };
            return types;
        }

        public override void OnBehaviourEnable()
        {
            _data.TryGetValue(typeof(RenderData), out var rData);
            _renderData = (RenderData) rData;
            
            _data.TryGetValue(typeof(EarthData), out var eData);
            _earthData = (EarthData) eData;
        }

        public void TickFixed()
        {
            var rb = _renderData.rigidbody;
            var gravityUp = (rb.position - _earthData.earthPosition).normalized;
            var localUp = rb.transform.up;
            
            rb.MoveRotation(Quaternion.FromToRotation(localUp, gravityUp) * rb.rotation);
            rb.MovePosition(rb.position.normalized * _earthData.earthRadius);
        }
    }
}