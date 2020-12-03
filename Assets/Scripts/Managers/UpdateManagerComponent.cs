using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class UpdateManagerComponent : MonoBehaviour
    {
        private UpdateManager _updateManager;

        public void Setup(UpdateManager mng)
        {
            _updateManager = mng;
        }
        
        private void Update()
        {
            _updateManager.Tick();
        }

        private void FixedUpdate()
        {
            _updateManager.TickFixed();
        }


        private void LateUpdate()
        {
            _updateManager.TickLate();
        }
    }
}