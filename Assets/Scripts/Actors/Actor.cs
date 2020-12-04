using System;
using System.Collections.Generic;
using Behaviours;
using Core;
using Data;
using Managers;
using UnityEditor;
using UnityEngine;
using Views;

namespace Actors
{
    public class Actor : MonoBehaviour
    {
        [SerializeField] private ActorInfo _actorInfo;
        [SerializeField] private UpdateContainer _updateContainer;
        [SerializeField] private DataContainer _inputDataContainer;
        

        [Serializable]
        public class ActorInfo
        {
            public string id;
            public List<string> tags;
        }

        [Serializable]
        public class UpdateContainer
        {
            public List<BaseBehaviour> setupBehaviours;
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
        private bool _loaded;

        private void Awake()
        {
            BuildBehavioursList();
            BuildDataDictionary();
            FillDataFromView();
            UpdateBehavioursData();
            _loaded = true;
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

        private void OnValidate()
        {
            if (_loaded && EditorApplication.isPlaying)
            {
                Debug.Log("Validate");
                RemoveBehavioursFromUpdateManager();
                BuildBehavioursList();
                UpdateBehavioursData();
                CallEnableBehaviours();
                AddBehavioursToUpdateManager();
            }

        }

        private void BuildBehavioursList()
        {
            _behaviours = new List<BaseBehaviour>();
            _updateContainer.setupBehaviours.ForEach(p => _behaviours.Add(Instantiate(p)));
            _updateContainer.updates.ForEach(p => _behaviours.Add(Instantiate(p)));
            _updateContainer.fixedUpdates.ForEach(p => _behaviours.Add(Instantiate(p)));
            _updateContainer.lateUpdates.ForEach(p => _behaviours.Add(Instantiate(p)));
        }

        private void BuildDataDictionary()
        {
            foreach (var data in _inputDataContainer.data)
            {
                _data.Add(data.GetType(), Instantiate(data));
            }
        }

        protected BaseData GetData(Type type)
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

        protected virtual void FillDataFromView()
        {
        }
    }
}