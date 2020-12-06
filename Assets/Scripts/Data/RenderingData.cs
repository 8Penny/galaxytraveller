using UnityEngine;

namespace Data {
    [CreateAssetMenu(fileName = "RenderingData", menuName = "Data/RenderingData")]
    public class RenderingData : BaseData {
        [HideInInspector]
        public Transform transform;
    }
}