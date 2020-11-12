using System;
using Objects;
using UnityEngine;

namespace Managers
{
    public class GameManager:MonoBehaviour
    {
        [SerializeField] private EnvironmentSpawner _environmentSpawner;

        private void Start()
        {
            _environmentSpawner.GenerateEnvironment();
        }
    }
}