using UnityEngine;

namespace Objects
{
    public class RockEnvironmentElement: IEnvironmentElement
    {
        public Vector3 position => _position;
        private Vector3 _position;

        public bool SetPosition(Vector3 v)
        {
            _position = v;
            return true;
        }
    }
}