using System;
using System.Collections.Generic;
using Data;
using Interfaces;
using UnityEngine;

namespace Behaviours
{
    [CreateAssetMenu(fileName = "MovementBehaviour", menuName = "Behaviours/MovementBehaviour")]
    public class MovementBehaviour : BaseBehaviour, ITickFixed
    {
        private MovementData _movementData;
        private RBData _rbData;
        private PlayerInputData _playerInputData;

        public override IEnumerable<Type> GetDataTypeNeed()
        {
            var types = new List<Type>()
            {
                typeof(MovementData),
                typeof(RBData),
                typeof(PlayerInputData)
            };
            return types;
        }

        public override void OnBehaviourEnable()
        {
            _data.TryGetValue(typeof(MovementData), out var moveData);
            _movementData = (MovementData) moveData;

            _data.TryGetValue(typeof(RBData), out var renderData);
            _rbData = (RBData) renderData;

            _data.TryGetValue(typeof(PlayerInputData), out var inputData);
            _playerInputData = (PlayerInputData) inputData;
        }

        public void TickFixed()
        {
            var playerRotation = _rbData.rigidbody.rotation;
            var moveDirection = playerRotation * new Vector3(0, 0, _playerInputData.vertical);

            var rotationDirection = new Vector3(0, _playerInputData.horizontal * _movementData.rotationSpeed, 0);
            var deltaRotation = Quaternion.Euler(rotationDirection);
            var targetRotation = playerRotation * deltaRotation;
            playerRotation = Quaternion.Lerp(playerRotation, targetRotation, Time.fixedTime);

            var playerPosition = _rbData.rigidbody.position +
                                  moveDirection * (_movementData.movementSpeed * Time.fixedDeltaTime);
            
            _rbData.rigidbody.MoveRotation(playerRotation);

            if (moveDirection == Vector3.zero)
            {
                _rbData.rigidbody.velocity /= 2;
                return;
            }

            _rbData.rigidbody.MovePosition(playerPosition);
        }
    }
}