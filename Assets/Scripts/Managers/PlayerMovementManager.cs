using System;
using Core;
using UnityEngine;

namespace Managers
{
    public class PlayerMovementManager : MonoBehaviour
    {
        [SerializeField] private Rigidbody _playerRigitbody;

        private const float MovementSpeed = 2.5f;
        private const float RotationSpeed = 3f;

        private Vector3 _smoothMoveVelocity;
        private Vector3 _moveAmount;
        private Vector3 _moveDirection;
        private Vector3 _rotationDirection;

        private Vector3 _playerPosition;
        private Quaternion _playerRotation;


        private void Start()
        {
            _playerRigitbody.freezeRotation = true;
        }
        
        private void Update()
        {
            var inputHorizontal = Input.GetAxisRaw("Horizontal");
            var inputVertical = Input.GetAxisRaw("Vertical");

            var direction = new Vector3(0, 0, inputVertical);
            var playerRotation = _playerRigitbody.rotation;
            _moveDirection = playerRotation * direction;

            _rotationDirection = new Vector3(0, inputHorizontal, 0);
        }
        public void MovePlayer()
        {
            Move();
            SavePlayerPosition();
        }

        private void Move()
        {
            var playerRotation = _playerRigitbody.rotation;
            var deltaRotation = Quaternion.Euler(_rotationDirection);
            var targetRotation = playerRotation * deltaRotation;
            _playerRotation = Quaternion.Lerp(_playerRigitbody.rotation, targetRotation,
                Time.fixedDeltaTime * RotationSpeed * 100f);

            _playerPosition = _playerRigitbody.position + _moveDirection * (MovementSpeed * Time.fixedDeltaTime);
            _playerRigitbody.MoveRotation(_playerRotation);

            if (_moveDirection == Vector3.zero)
            {
                _playerRigitbody.velocity /= 2;
                return;
            }
            _playerRigitbody.MovePosition(_playerPosition);
        }

        private void SavePlayerPosition()
        {
            var player = Game.instance.player;
            player.SetPosition(_playerPosition);
            player.SetRotation(_playerRotation.eulerAngles.y);
        }


        public void UpdatePlayerPositionAndRotation()
        {
            var player = Game.instance.player;
            _playerRigitbody.MoveRotation(Quaternion.Euler(0, player.rotation, 0));
            _playerRigitbody.MovePosition(player.position);
        }

    }
}