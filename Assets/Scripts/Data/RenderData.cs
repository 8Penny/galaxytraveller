using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "RenderData", menuName = "Data/RenderData")]
    public class RenderData : BaseData
    {
        [HideInInspector] public Transform transform;
        [HideInInspector] public Rigidbody rigidbody;
        [HideInInspector] public BoxCollider boxCollider;
    }
}