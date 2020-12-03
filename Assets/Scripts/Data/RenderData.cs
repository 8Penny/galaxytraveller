using UnityEngine;

namespace Data
{
    [CreateAssetMenu]
    public class RenderData : BaseData
    {
        public Transform transform;
        public Rigidbody rigidbody;
        public BoxCollider boxCollider;
    }
}