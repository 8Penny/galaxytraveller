using System;
using System.Collections.Generic;
using Data;
using Interfaces;
using UnityEngine;

namespace Behaviours
{
    [CreateAssetMenu]
    public class MovementBehaviour : BaseBehaviour, ITickFixed
    {
        private MovementData _movementData;
        private RenderData _renderData;
        private PlayerInputData _playerInputData;

        public override IEnumerable<Type> GetDataTypeNeed()
        {
            var types = new List<Type>()
            {
                typeof(MovementData),
                typeof(RenderData),
                typeof(PlayerInputData)
            };
            return types;
        }

        public override void OnBehaviourEnable()
        {
            _data.TryGetValue(typeof(MovementData), out var moveData);
            _movementData = (MovementData) moveData;

            _data.TryGetValue(typeof(RenderData), out var renderData);
            _renderData = (RenderData) renderData;

            _data.TryGetValue(typeof(PlayerInputData), out var inputData);
            _playerInputData = (PlayerInputData) inputData;
        }

        public void TickFixed()
        {
            var playerRotation = _renderData.rigidbody.rotation;
            var moveDirection = playerRotation * new Vector3(0, 0, _playerInputData.vertical);

            var rotationDirection = new Vector3(0, _playerInputData.horizontal * _movementData.rotationSpeed, 0);
            var deltaRotation = Quaternion.Euler(rotationDirection);
            var targetRotation = playerRotation * deltaRotation;
            playerRotation = Quaternion.Lerp(playerRotation, targetRotation, Time.fixedTime);

            var playerPosition = _renderData.rigidbody.position +
                                  moveDirection * (_movementData.movementSpeed * Time.fixedDeltaTime);
            
            _renderData.rigidbody.MoveRotation(playerRotation);

            if (moveDirection == Vector3.zero)
            {
                _renderData.rigidbody.velocity /= 2;
                return;
            }

            _renderData.rigidbody.MovePosition(playerPosition);
        }
    }
}