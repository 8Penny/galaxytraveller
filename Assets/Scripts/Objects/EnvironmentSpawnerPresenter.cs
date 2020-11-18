using System.Linq;
using Managers;
using UnityEngine;

namespace Objects
{
    public class EnvironmentSpawnerPresenter: MonoBehaviour
    {
        [SerializeField] private EnvironmentSpawnerView _spawnerView;
        
        private PointsManager _pointsManager;
        private uint _spawnedObjects;
        public void GenerateEnvironment()
        {
            _pointsManager = new PointsManager(_spawnerView.pointsOnPlanetCount, _spawnerView.busyZones);
            SpawnRocks();
        }

        private void SpawnRocks()
        {
            var weightSum = 0;
            foreach (var rock in _spawnerView.rocks)
            {
                weightSum += rock.weight;
            }

            var rocksLeft = _spawnerView.rockElementsCount;
            foreach (var rock in _spawnerView.rocks)
            {
                var rocksCount = (uint)(_spawnerView.rockElementsCount * rock.weight / weightSum);
                Debug.Log($"rockCount {rocksCount} {rock.weight}");
                SpawnElements(rock.prefab, rocksCount, true);
                rocksLeft -= rocksCount;
            }

            var extraRock = _spawnerView.rocks[Random.Range(0, _spawnerView.rocks.Length)];
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
                var element = Instantiate(prefab, _spawnerView.planetGO);
                element.transform.position = (position * _spawnerView.earthGO.transform.localScale.x)/2.2f;
                element.transform.LookAt(_spawnerView.earthGO);
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