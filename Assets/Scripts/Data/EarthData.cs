using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "EarthData", menuName = "Data/EarthData")]
    public class EarthData: BaseData
    {
        [HideInInspector] public Transform transform;
        public float earthRadius;
        public Vector3 earthPosition;
    }
}