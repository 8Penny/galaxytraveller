using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "MovementData", menuName = "Data/MovementData")]
    public class MovementData : BaseData
    {
        public float movementSpeed = 2.5f;
        public float rotationSpeed = 1.7f;
    }
}