using System;
using Managers;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;


namespace Objects
{
    public class EnvironmentSpawnerView : MonoBehaviour
    {
        [SerializeField] private Transform _planetGO = null;
        [SerializeField] private Transform _earthGO = null;
        [SerializeField] private ItemToSpawn[] _rocks = null;

        [SerializeField] private uint _pointsOnPlanetCount = 0;
        [SerializeField] private uint _rockElementsCount = 0;

        [SerializeField] private BusyZone[] _busyZones = null;

        public Transform planetGO => _planetGO;
        public Transform earthGO => _earthGO;
        public ItemToSpawn[] rocks => _rocks;

        public uint pointsOnPlanetCount => _pointsOnPlanetCount;
        public uint rockElementsCount => _rockElementsCount;

        public BusyZone[] busyZones => _busyZones;
    }
}