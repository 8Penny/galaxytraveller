using System.Collections.Generic;
using System.Linq;
using Managers;
using UnityEngine;

namespace Objects
{
    public class EnvironmentSpawnerPresenter : MonoBehaviour
    {
        [SerializeField] private EnvironmentSpawnerView _spawnerView;

        private PointsManager _pointsManager;
        private uint _spawnedObjects;

        public List<EnvironmentElement> GenerateEnvironmentData()
        {
            _pointsManager = new PointsManager(_spawnerView.pointsOnPlanetCount, _spawnerView.busyZones);
            var elements = GenerateRockData();
            return elements;
        }

        private List<EnvironmentElement> GenerateRockData()
        {
            var rocks = new List<EnvironmentElement>();
            var weightSum = 0;
            foreach (var rock in _spawnerView.rocks)
            {
                weightSum += rock.weight;
            }

            var rocksLeft = _spawnerView.rockElementsCount;
            foreach (var rock in _spawnerView.rocks)
            {
                var rocksCount = (uint) (_spawnerView.rockElementsCount * rock.weight / weightSum);
                rocksLeft -= rocksCount;
                if (rocksLeft == 1)
                {
                    rocksCount += 1;
                    rocksLeft = 0;
                }

                var positions = GetFreePositions(rocksCount);

                foreach (var position in positions)
                {
                    var rotation = new Vector3(0.0f, Random.Range(0.0f, 360.0f), 0.0f);
                    var rockData = new RockEnvironmentElement(position, rotation, rock.id);
                    rocks.Add(rockData);

                    ++_spawnedObjects;
                }
            }

            return rocks;
        }

        public void InstantiateEnvironment(IEnumerable<EnvironmentElement> elements)
        {
            foreach (var element in elements)
            {
                var el = element as RockEnvironmentElement;
                var prefab = _spawnerView.rocks[el.Id].prefab;
                var gameObj = Instantiate(prefab, _spawnerView.planetGO);
                gameObj.transform.position = el.position;
                gameObj.transform.LookAt(_spawnerView.earthGO);
                gameObj.transform.Rotate(-90, 0, 0);

                gameObj.transform.GetChild(0).transform.Rotate(el.rotation);

                ++_spawnedObjects;
            }
        }


        private IEnumerable<Vector3> GetFreePositions(uint elementCount)
        {
            var positions = new List<Vector3>();
            var rawPositions = _pointsManager.GetRawFreePositions(elementCount);
            if (rawPositions == null)
            {
                return null;
            }

            foreach (var position in rawPositions)
            {
                positions.Add(position * (_spawnerView.earthGO.transform.localScale.x / 2.2f));
            }

            return positions;
        }
    }
}