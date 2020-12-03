using System;
using System.Collections.Generic;
using Data;
using UnityEngine;

namespace Behaviours
{
    public class BaseBehaviour : ScriptableObject
    {
        protected Dictionary<Type, BaseData> _data;

        public virtual IEnumerable<Type> GetDataTypeNeed()
        {
            var types = new List<Type>() {typeof(BaseData)};
            return types;
        }

        public void SetData(Dictionary<Type, BaseData> data)
        {
            _data = data;
        }

        public virtual void OnBehaviourEnable()
        {
        }

        public virtual void OnBehaviourDisable()
        {
        }
    }
}