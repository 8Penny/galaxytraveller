using System;
using UnityEngine;

namespace Managers
{
    public class PlayerMovementManager : MonoBehaviour
    {
        [SerializeField] private Rigidbody _playerRigitbody;
        [SerializeField] private Transform _playerTransform;


        private const float MovementSpeed = 2.5f;
        private const float RotationSpeed = 3f;

        private Vector3 _smoothMoveVelocity;
        private Vector3 _moveAmount;
        private Vector3 _moveDirection;
        private Vector3 _rotationDirection;


        private void Update()
        {
            var inputHorizontal = Input.GetAxisRaw("Horizontal");
            var inputVertical = Input.GetAxisRaw("Vertical");

            var direction = new Vector3(0, 0, inputVertical);
            var playerRotation = _playerRigitbody.rotation;
            _moveDirection = playerRotation * direction;

            _rotationDirection = new Vector3(0, inputHorizontal, 0);
        }

        public void Move()
        {
            var playerRotation = _playerRigitbody.rotation;
            var deltaRotation = Quaternion.Euler(_rotationDirection);
            var targetRotation = playerRotation * deltaRotation;
            var smoothRotation = Quaternion.Lerp(_playerRigitbody.rotation, targetRotation,
                Time.fixedDeltaTime * RotationSpeed * 100f);

            var position = _playerRigitbody.position + _moveDirection * (MovementSpeed * Time.fixedDeltaTime);

            _playerRigitbody.MoveRotation(smoothRotation);
            _playerRigitbody.MovePosition(position);
        }

        private void Start()
        {
            _playerRigitbody.freezeRotation = true;
        }
    }
}