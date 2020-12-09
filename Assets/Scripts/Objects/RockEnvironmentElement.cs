using UnityEngine;
using Utils;

namespace Objects
{
    [System.Serializable]
    public class RockEnvironmentElement : EnvironmentElement
    {
        public RockEnvironmentElement(Vector3 pos, Vector3 rot, string id, int type) : base(pos, rot, id, type)
        {

        }
    }
}