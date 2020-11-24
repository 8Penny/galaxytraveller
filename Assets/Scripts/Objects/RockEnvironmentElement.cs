using UnityEngine;
using Utils;

namespace Objects
{
    [System.Serializable]
    public class RockEnvironmentElement : EnvironmentElement
    {
        private int _rockType;
        public SerializableVector3 position => _position;
        public SerializableVector3 rotation => _rotation;
        public int Id => _id;

        public RockEnvironmentElement(Vector3 pos, Vector3 rot, int id)
        {
            _position = pos;
            _rotation = rot;
            _id = id;
        }
    }
}