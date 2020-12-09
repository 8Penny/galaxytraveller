using System.Collections.Generic;
using Core;
using Objects;
using UnityEngine;

namespace Managers {
    [CreateAssetMenu(fileName = "HomeLocationManager", menuName = "Managers/HomeLocationManager")]
    public class HomeLocationManager : BaseManager {
        private List<EnvironmentElement> _environmentElements;

        public void SetEnvironmentElements(List<EnvironmentElement> environmentElements) {
            _environmentElements = environmentElements;
            GameCore.Get<SaveLoadManager>().SaveGame();
        }

        public List<EnvironmentElement> GetEnvironmentElements() {
            return _environmentElements;
        }

        public bool RemoveEnvironmentElement(string id, Vector3 position) {
            var element = _environmentElements.Find(e => e.id == id && e.position == position);
            if (element == null) {
                return false;
            }

            _environmentElements.Remove(element);
            return true;
        }
    }
}