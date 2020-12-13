using System;
using System.Collections.Generic;
using Core;
using Data;
using Interfaces;
using Managers;
using UnityEngine;

namespace Behaviours
{
    [CreateAssetMenu(fileName = "PlayerInputBehaviour", menuName = "Behaviours/PlayerInputBehaviour")]
    public class PlayerInputBehaviour : BaseBehaviour, ITick
    {
        private PlayerInputData _playerInputData;
        private Joystick _joystick;
        public override IEnumerable<Type> GetDataTypeNeed()
        {
            var types = new List<Type>()
            {
                typeof(PlayerInputData),
            };
            return types;
        }

        public override void OnBehaviourEnable()
        {
            _data.TryGetValue(typeof(PlayerInputData), out var data);
            _playerInputData = (PlayerInputData) data;
            var inputMng = GameCore.Get<InputManager>();
            _joystick = inputMng.joystick;
        }
        public void Tick() {
            _playerInputData.horizontal = _joystick.Horizontal;
            _playerInputData.vertical = _joystick.Vertical;
        }
    }
}