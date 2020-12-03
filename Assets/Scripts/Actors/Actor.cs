using System;
using System.Collections.Generic;
using Behaviours;
using Core;
using Data;
using Managers;
using UnityEngine;
using Views;

namespace Actors
{
    public class Actor : MonoBehaviour
    {
        [SerializeField] private ActorInfo _actorInfo;
        [SerializeField] private UpdateContainer _updateContainer;
        [SerializeField] private DataContainer _inputDataContainer;
        [SerializeField] private PlayerView _playerView;

        [Serializable]
        public class ActorInfo
        {
            public string id;
            public List<string> tags;
        }

        [Serializable]
        public class UpdateContainer
        {
            public List<BaseBehaviour> updates;
            public List<BaseBehaviour> fixedUpdates;
            public List<BaseBehaviour> lateUpdates;
        }

        [Serializable]
        public class DataContainer
        {
            public List<BaseData> data;
        }

        private Dictionary<Type, BaseData> _data = new Dictionary<Type, BaseData>();
        private List<BaseBehaviour> _behaviours = new List<BaseBehaviour>();

        private void Awake()
        {
            BuildBehavioursList();
            BuildDataDictionary();
            FillRenderData();
            UpdateBehavioursData();
        }

        private void OnEnable()
        {
            CallEnableBehaviours();
            AddBehavioursToUpdateManager();
        }

        private void OnDisable()
        {
            CallDisableBehaviours();
            RemoveBehavioursFromUpdateManager();
        }

//        private void OnValidate()
//        {
//            BuildDataDictionary();
//            UpdateBehavioursData();
//            RemoveBehavioursFromUpdateManager();
//            AddBehavioursToUpdateManager();
//        }

        private void BuildBehavioursList()
        { 
            _updateContainer.updates.ForEach(p => _behaviours.Add(p));
            _updateContainer.fixedUpdates.ForEach(p => _behaviours.Add(p));
            _updateContainer.lateUpdates.ForEach(p => _behaviours.Add(p));
        }

        private void BuildDataDictionary()
        {
            foreach (var data in _inputDataContainer.data)
            {
                _data.Add(data.GetType(), Instantiate(data));
            }
        }

        private BaseData GetData(Type type)
        {
            if (_data.TryGetValue(type, out var data))
            {
                return data;
            }

            Debug.LogError($"There is no data of type {type} in data container of {gameObject.name}");
            return null;
        }

        private void UpdateBehavioursData()
        {
            UpdateSpecificBehaviours(_behaviours);
        }

        private void UpdateSpecificBehaviours(IEnumerable<BaseBehaviour> behaviours)
        {
            foreach (var behaviour in behaviours)
            {
                var needTypes = behaviour.GetDataTypeNeed();
                var dict = new Dictionary<Type, BaseData>();
                foreach (var type in needTypes)
                {
                    dict.Add(type, GetData(type));
                }

                behaviour.SetData(dict);
            }
        }

        private void AddBehavioursToUpdateManager()
        {
            foreach (var behaviour in _behaviours)
            {
                UpdateManager.AddTo(behaviour);
            }
        }

        private void RemoveBehavioursFromUpdateManager()
        {
            foreach (var behaviour in _behaviours)
            {
                UpdateManager.RemoveFrom(behaviour);
            }
        }

        private void CallEnableBehaviours()
        {
            foreach (var behaviour in _behaviours)
            {
                behaviour.OnBehaviourEnable();
            }
        }

        private void CallDisableBehaviours()
        {
            foreach (var behaviour in _behaviours)
            {
                behaviour.OnBehaviourDisable();
            }
        }

        private void FillRenderData()
        {
            var renderData = GetData(typeof(RenderData)) as RenderData;
            if (renderData == null)
            {
                return;
            }

            renderData.rigidbody = _playerView.rigidbody;
            renderData.transform = _playerView.transform;
            renderData.boxCollider = _playerView.boxCollider;
        }
    }
}