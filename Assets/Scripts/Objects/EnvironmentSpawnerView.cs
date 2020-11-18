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

        public Transform planetGO => _planetGO;
        public Transform earthGO => _earthGO;
        public ItemToSpawn[] rocks => _rocks;

        public uint pointsOnPlanetCount => _pointsOnPlanetCount;
        public uint rockElementsCount => _rockElementsCount;

        public BusyZone[] busyZones => _busyZones;
    }
}