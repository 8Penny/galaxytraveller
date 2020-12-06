using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "RigidBodyData", menuName = "Data/RigidBodyData")]
    public class RBData : BaseData
    {
        [HideInInspector] public Rigidbody rigidbody;
    }
}