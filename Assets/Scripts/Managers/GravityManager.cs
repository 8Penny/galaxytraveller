using System;
using UnityEngine;

namespace Managers
{
    public class GravityManager : MonoBehaviour
    {
        [SerializeField] private Transform _earthGO;
        [SerializeField] private Rigidbody _playerRigitbody;

        private const float Gravity = -9.8f;

        public void Attract()
        {
            var gravityUp = (_playerRigitbody.position - _earthGO.position).normalized;
            var localUp = _playerRigitbody.transform.up;

            _playerRigitbody.AddForce(gravityUp * Gravity);
            _playerRigitbody.MoveRotation(Quaternion.FromToRotation(localUp, gravityUp) * _playerRigitbody.rotation);
        }
    }
}