using System;
using System.Collections.Generic;
using Core;
using Objects;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private EnvironmentSpawnerPresenter _environmentSpawner;
        [SerializeField] private GravityManager _gravityManager;
        [SerializeField] private PlayerMovementManager _playerMovementManager;

        private SaveManager _saveManager;
        private bool _loaded;

        private void Awake()
        {
            var game = new Game();
            
            _saveManager = new SaveManager();
            var save = _saveManager.LoadGame();
            

            if (save != null)
            {
                game.LoadGameData(save);
                _playerMovementManager.UpdatePlayerPositionAndRotation();
            }
            else
            {
                var homeEnvironment = _environmentSpawner.GenerateEnvironmentData();
                game.homePlanet.FillEnvironmentElements(homeEnvironment);
            }

            _environmentSpawner.InstantiateEnvironment(game.homePlanet.environmentElements);
            _loaded = true;
        }

        private void FixedUpdate()
        {
            if (!_loaded)
            {
                return;
            }
            _playerMovementManager.MovePlayer();
            _gravityManager.Attract();
        }

        private void OnApplicationQuit()
        {
            _saveManager.SaveGame();
        }
    }
}