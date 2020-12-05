using System.Collections.Generic;
using Core;
using Objects;
using UnityEngine;

namespace Managers
{
    [CreateAssetMenu(fileName = "HomeLocationManager", menuName = "Managers/HomeLocationManager")]
    public class HomeLocationManager : BaseManager
    {
        private List<EnvironmentElement> _environmentElements;

        public void SetEnvironmentElements(List<EnvironmentElement> environmentElements)
        {
            _environmentElements = environmentElements;
            GameCore.Get<SaveLoadManager>().SaveGame();
        }
        
        public List<EnvironmentElement> GetEnvironmentElements()
        {
            return _environmentElements;
        }
    }
}