using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "PlanetData", menuName = "Data/PlanetData")]
    public class PlanetData: BaseData
    {
        [HideInInspector] public Transform transform;
        public float radius;
        public Vector3 position;
    }
}