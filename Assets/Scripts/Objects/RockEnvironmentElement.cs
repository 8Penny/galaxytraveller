using UnityEngine;

namespace Objects
{
    public class RockEnvironmentElement: EnvironmentElement
    {
        private int _rockType;
        public Vector3 position => _position;
        public Vector3 rotation => _rotation;
        public int rockType => _eType;

        public RockEnvironmentElement(Vector3 pos, Vector3 rot, int rockType)
        {
            _position = pos;
            _rotation = rot;
            _eType = rockType;
        }
    }
}