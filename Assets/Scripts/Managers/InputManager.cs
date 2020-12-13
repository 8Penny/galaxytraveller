using Core;
using Interfaces;
using UnityEngine;

namespace Managers {
    [CreateAssetMenu(fileName = "InputManager", menuName = "Managers/InputManager")]
    public class InputManager: BaseManager, IAwake {
        private Joystick _joystick;
        public Joystick joystick => _joystick;
        
        
        public void OnAwake() {
            _joystick = FindObjectOfType<FixedJoystick>();
        }

    }
}