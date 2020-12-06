using System.Collections;
using System.Collections.Generic;
using Core;
using Data;
using Data.Spawner;
using Interfaces;
using Objects;
using UnityEngine;
using Utils;

namespace Managers
{
    [CreateAssetMenu(fileName = "EnvironmentSpawnerManager", menuName = "Managers/EnvironmentSpawnerManager")]
    public class EnvironmentSpawnerManager : BaseManager, IAwake
    {
        public SpawnerData data;


        private Stack<Vector3> _freePositions;
        private Transform _planet;

        public void OnAwake()
        {
            _planet = GameObject.FindWithTag(Tags.Location).transform;
            GenerateAllPositionsOnPlanet();

            var saveLoadMng = GameCore.Get<SaveLoadManager>();
            var homeEnv = saveLoadMng.GetEnvironment();
            if ((homeEnv?.Count ?? 0) == 0)
            {
                homeEnv = GenerateRockData();

                var homeLocationMng = GameCore.Get<HomeLocationManager>();
                homeLocationMng.SetEnvironmentElements(homeEnv);
            }

            InstantiateEnvironment(homeEnv);
        }

        private void GenerateAllPositionsOnPlanet()
        {
            var multiplier = data.planetData.radius / 1.1f;
            var positions = MathExtensions.GeneratePointsOnSphere(data.pointsOnPlanetCount, multiplier);
            var rnd = new System.Random();
            rnd.Shuffle(positions, positions.Length);
            _freePositions = new Stack<Vector3>(positions);
        }

        private void InstantiateEnvironment(IEnumerable<EnvironmentElement> elements)
        {
            foreach (var element in elements)
            {
                var el = element as RockEnvironmentElement;
                var prefab = data.rocks[el.Id].prefab;
                var gameObj = Instantiate(prefab, _planet);
                gameObj.transform.position = el.position;
                gameObj.transform.LookAt(data.planetData.position);
                gameObj.transform.Rotate(-90, 0, 0);

                gameObj.transform.GetChild(0).transform.Rotate(el.rotation);
            }
        }

        private List<EnvironmentElement> GenerateRockData()
        {
            var rocks = new List<EnvironmentElement>();
            var weightSum = 0;
            foreach (var rock in data.rocks)
            {
                weightSum += rock.weight;
            }

            var rocksLeft = data.rockElementsCount;
            foreach (var rock in data.rocks)
            {
                var rocksCount = data.rockElementsCount * rock.weight / weightSum;
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
                }
            }

            return rocks;
        }

        private IEnumerable<Vector3> GetFreePositions(int count)
        {
            var positions = new List<Vector3>();
            while (_freePositions.Count != 0 && positions.Count < count)
            {
                var pos = _freePositions.Pop();
                if (IsInEmptyZone(pos))
                {
                    continue;
                }

                positions.Add(pos);
            }

            return positions;
        }

        private bool IsInEmptyZone(Vector3 point)
        {
            foreach (var zone in data.busyZones)
            {
                var distance = Vector3.Distance(point, zone.position);
                if (distance < zone.radius)
                {
                    return true;
                }
            }

            return false;
        }
    }
}