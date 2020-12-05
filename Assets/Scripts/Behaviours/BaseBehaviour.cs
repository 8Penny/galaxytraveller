using System;
using System.Collections.Generic;
using Data;
using Interfaces;
using UnityEngine;

namespace Behaviours
{
    public abstract class BaseBehaviour : ScriptableObject
    {
        protected Dictionary<Type, BaseData> _data;

        public abstract IEnumerable<Type> GetDataTypeNeed();

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