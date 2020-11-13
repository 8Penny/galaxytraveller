using System;
using Objects;
using UnityEngine;

namespace Managers
{
    public class GameManager:MonoBehaviour
    {
        [SerializeField] private EnvironmentSpawnerPresenter _environmentSpawner;
        [SerializeField] private GravityManager _gravityManager;
        [SerializeField] private PlayerMovementManager _playerMovementManager;
        private void Start()
        {
            _environmentSpawner.GenerateEnvironment();
        }

        private void FixedUpdate()
        {
            _playerMovementManager.Move();
            _gravityManager.Attract();
            
        }
    }
}