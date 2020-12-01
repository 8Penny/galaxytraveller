using System;
using UnityEngine;

namespace Managers
{
    public class GravityManager : MonoBehaviour
    {
        [SerializeField] private Transform _earthGO = null;
        [SerializeField] private Rigidbody _playerRigitbody = null;
        
        private float _earthRadius;

        private void Awake()
        {
            _earthRadius = _earthGO.localScale.x / 2;
        }

        public void Attract()
        {
            var gravityUp = (_playerRigitbody.position - _earthGO.position).normalized;
            var localUp = _playerRigitbody.transform.up;
            
            _playerRigitbody.MoveRotation(Quaternion.FromToRotation(localUp, gravityUp) * _playerRigitbody.rotation);
            _playerRigitbody.MovePosition(_playerRigitbody.position.normalized * _earthRadius);
        }
    }
}