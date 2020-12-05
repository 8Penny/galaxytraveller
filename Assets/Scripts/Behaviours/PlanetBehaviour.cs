using System;
using System.Collections.Generic;
using Data;
using Interfaces;
using UnityEngine;

namespace Behaviours
{
    [CreateAssetMenu(fileName = "PlanetBehaviour", menuName = "Behaviours/PlanetBehaviour")]
    public class PlanetBehaviour: BaseBehaviour , IAwake
    {
        private PlanetData _planetData;
        public override IEnumerable<Type> GetDataTypeNeed()
        {
            var types = new List<Type>()
            {
                typeof(PlanetData),
            };
            return types;
        }

        public void OnAwake()
        {
            _data.TryGetValue(typeof(PlanetData), out var pData);
            _planetData = (PlanetData) pData;
            var scale = _planetData.radius * 2;
            _planetData.transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}