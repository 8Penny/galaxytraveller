using System;
using Managers;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;


namespace Objects
{

    public class EnvironmentSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _planetGO;
        [SerializeField] private Transform _earthGO;
        [SerializeField] private ItemToSpawn[] _rocks;

        [SerializeField] private uint _pointsOnPlanetCount;
        [SerializeField] private uint _rockElementsCount;

        [SerializeField] private BusyZone[] _busyZones;

        private PointsManager _pointsManager;
        private uint _spawnedObjects;
        public void GenerateEnvironment()
        {
            _pointsManager = new PointsManager(_pointsOnPlanetCount, _busyZones);
            SpawnRocks();
        }

        private void SpawnRocks()
        {
            var weightSum = 0;
            foreach (var rock in _rocks)
            {
                weightSum += rock.weight;
            }

            var rocksLeft = _rockElementsCount;
            foreach (var rock in _rocks)
            {
                var rocksCount = (uint)(_rockElementsCount * rock.weight / weightSum);
                Debug.Log($"rockCount {rocksCount} {rock.weight}");
                SpawnElements(rock.prefab, rocksCount, true);
                rocksLeft -= rocksCount;
            }

            var extraRock = _rocks[Random.Range(0, _rocks.Length)];
            SpawnElements(extraRock.prefab, rocksLeft, true);
            Debug.Log(_spawnedObjects);
        }

        private void SpawnElements(GameObject prefab, uint elementCount, bool needYRotation = false)
        {
            var positions = _pointsManager.GetFreePoints(elementCount);
            if (positions == null)
            {
                return;
            }

            foreach (var position in positions)
            {
                var element = Instantiate(prefab, _planetGO);
                element.transform.position = position * _earthGO.transform.localScale.x/2.2f;
                element.transform.LookAt(_earthGO);
                element.transform.Rotate(-90, 0, 0);

                if (needYRotation)
                {
                    element.transform.GetChild(0).transform.Rotate(0.0f, Random.Range(0.0f, 360.0f), 0.0f);
                }
                
                ++_spawnedObjects;
            }
        }
    }
}