using System;
using UnityEngine;

namespace Data {
    [CreateAssetMenu(fileName = "InteractableData", menuName = "Data/InteractableData")]
    public class InteractableData : BaseData {
        public int type;
        public float interactionTime;
        public float interactionLightScale;
    }
}