using System;
using System.Collections.Generic;
using Data;
using UnityEngine;
using Views.Earth;

namespace Behaviours
{
    [CreateAssetMenu(fileName = "EarthBehaviour", menuName = "Behaviours/EarthBehaviour")]
    public class EarthBehaviour: BaseBehaviour 
    {
        private EarthData _earthData;
        public override IEnumerable<Type> GetDataTypeNeed()
        {
            var types = new List<Type>()
            {
                typeof(EarthData),
            };
            return types;
        }

        public override void OnBehaviourEnable()
        {
            _data.TryGetValue(typeof(EarthData), out var eData);
            _earthData = (EarthData) eData;
            var scale = _earthData.earthRadius * 2;
            _earthData.transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}