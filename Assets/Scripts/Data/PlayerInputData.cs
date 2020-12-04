using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "PlayerInputData", menuName = "Data/PlayerInputData")]
    public class PlayerInputData : BaseData
    {
        [HideInInspector] public float horizontal;
        [HideInInspector] public float vertical;
    }
}