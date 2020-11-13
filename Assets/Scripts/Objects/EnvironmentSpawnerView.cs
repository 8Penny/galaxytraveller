using System;
using Managers;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;


namespace Objects
{
    public class EnvironmentSpawnerView : MonoBehaviour
    {
        [SerializeField] private Transform _planetGO;
        [SerializeField] private Transform _earthGO;
        [SerializeField] private ItemToSpawn[] _rocks;

        [SerializeField] private uint _pointsOnPlanetCount;
        [SerializeField] private uint _rockElementsCount;

        [SerializeField] private BusyZone[] _busyZones;

        public Transform PlanetGO => _planetGO;
        public Transform EarthGO => _earthGO;
        public ItemToSpawn[] Rocks => _rocks;

        public uint PointsOnPlanetCount => _pointsOnPlanetCount;
        public uint RockElementsCount => _rockElementsCount;

        public BusyZone[] BusyZones => _busyZones;
    }
}