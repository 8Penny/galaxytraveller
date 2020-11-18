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

        private void Start()
        {
            _saveManager = new SaveManager();
            var save = _saveManager.LoadGame();
            var game = new Game();

            if (save != null)
            {
                game.LoadGameData(save);
            }
            else
            {
                var homeEnvironment = _environmentSpawner.GenerateEnvironmentData();
                game.homePlanet.FillEnvironmentElements(homeEnvironment);
            }

            _environmentSpawner.InstantiateEnvironment(game.homePlanet.environmentElements);
        }

        private void FixedUpdate()
        {
            _playerMovementManager.Move();
            _gravityManager.Attract();
        }
    }
}