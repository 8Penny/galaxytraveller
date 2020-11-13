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
            _pointsManager = new PointsManager(_spawnerView.PointsOnPlanetCount, _spawnerView.BusyZones);
            SpawnRocks();
        }

        private void SpawnRocks()
        {
            var weightSum = 0;
            foreach (var rock in _spawnerView.Rocks)
            {
                weightSum += rock.weight;
            }

            var rocksLeft = _spawnerView.RockElementsCount;
            foreach (var rock in _spawnerView.Rocks)
            {
                var rocksCount = (uint)(_spawnerView.RockElementsCount * rock.weight / weightSum);
                Debug.Log($"rockCount {rocksCount} {rock.weight}");
                SpawnElements(rock.prefab, rocksCount, true);
                rocksLeft -= rocksCount;
            }

            var extraRock = _spawnerView.Rocks[Random.Range(0, _spawnerView.Rocks.Length)];
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
                var element = Instantiate(prefab, _spawnerView.PlanetGO);
                element.transform.position = position * _spawnerView.EarthGO.transform.localScale.x/2.2f;
                element.transform.LookAt(_spawnerView.EarthGO);
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