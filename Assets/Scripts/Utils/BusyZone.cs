using System;
using UnityEngine;

namespace Utils
{
    public class BusyZone : MonoBehaviour
    {
        [SerializeField] private Vector3 _position = Vector3.zero;
        [SerializeField] private float _radius = 0;
        
        public Vector3 position => _position; 
        public float radius => _radius;

        private void Start()
        {
            if (_position == Vector3.zero || radius == 0)
            {
                Debug.LogError("Empty BusyZone Object");
            }
        }
    }
}