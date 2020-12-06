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
        private RBData _rbData;
        private PlanetData _planetData;
        public override IEnumerable<Type> GetDataTypeNeed()
        {
            var types = new List<Type>()
            {
                typeof(RBData),
                typeof(PlanetData)
            };
            return types;
        }

        public override void OnBehaviourEnable()
        {
            _data.TryGetValue(typeof(RBData), out var rData);
            _rbData = (RBData) rData;
            
            _data.TryGetValue(typeof(PlanetData), out var eData);
            _planetData = (PlanetData) eData;
        }

        public void TickFixed()
        {
            var rb = _rbData.rigidbody;
            var gravityUp = (rb.position - _planetData.position).normalized;
            var localUp = rb.transform.up;
            
            rb.MoveRotation(Quaternion.FromToRotation(localUp, gravityUp) * rb.rotation);
            rb.MovePosition(rb.position.normalized * _planetData.radius);
        }
    }
}