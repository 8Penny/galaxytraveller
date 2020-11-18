using UnityEngine;

namespace Actors
{
    public class Creature
    {
        protected Vector3 _position;
        protected Vector3 _rotation;
        protected float _health;
        
        public Vector3 position => _position;
        public Vector3 rotation => _rotation;
        public float health => _health;

        public void SetPosition(Vector3 value)
        {
            _position = value;
        }
        
        public void SetRotation(Vector3 value)
        {
            _rotation = value;
        }
        
        public void SetHealth(float value)
        {
            _health = value;
        }
    }
}