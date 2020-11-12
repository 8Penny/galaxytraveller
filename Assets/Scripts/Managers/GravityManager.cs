using System;
using UnityEngine;

namespace Managers
{
    public class GravityManager : MonoBehaviour
    {
        [SerializeField] private Transform _earthGO;
        [SerializeField] private Rigidbody _playerRigitbody;
        [SerializeField] private Transform _playerTransform;

        private const float Gravity = -9.8f;

        private void FixedUpdate()
        {
            Attract();
        }

        private void Attract()
        {
            var gravityUp = (_playerTransform.position - _earthGO.position).normalized;
            var localUp = _playerTransform.up;

            _playerRigitbody.AddForce(gravityUp * Gravity);
            _playerRigitbody.MoveRotation(Quaternion.FromToRotation(localUp, gravityUp) * _playerTransform.rotation);
        }
    }
}