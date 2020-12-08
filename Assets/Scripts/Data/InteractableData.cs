using System;
using UnityEngine;

namespace Data {
    [CreateAssetMenu(fileName = "InteractableData", menuName = "Data/InteractableData")]
    public class InteractableData : BaseData {
        public InteractableType iType;
        public float interactionTime;
        [HideInInspector]
        public float interactionLightScale;

        public bool started;
        
        public delegate void EventHandler();
        private event EventHandler FinishedEvent;

        public void BindOnFinished(EventHandler function) {
            FinishedEvent += function;
        }

        public void LooseOnFinished(EventHandler function) {
            FinishedEvent += function;
        }

        public void CallOnFinished() {
            FinishedEvent?.Invoke();
        }
        
    }
    public enum InteractableType {
         Resource,
         Enemy
    }
}