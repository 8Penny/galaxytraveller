﻿using Core;
using Data;
using Data.PlayerStats;
using UnityEngine;

namespace Managers
{
    [CreateAssetMenu(fileName = "PlayerStatsManager", menuName = "Managers/PlayerStatsManager")]
    public class PlayerStatsManager: BaseManager
    {
        [SerializeField] private RenderData _rData;
        [SerializeField] private PlayerStatsData _stats;

        public Vector3 GetPosition()
        {
            return _stats.position;
        }
        
        public float GetRotation()
        {
            return _stats.rotation;
        }

        public uint GetRang()
        {
            return _stats.rang;
        }

        public uint GetPoints()
        {
            return _stats.points;
        }
        
        public float GetHealth()
        {
            return _stats.health;
        }
        
        public float GetEnergy()
        {
            return _stats.energy;
        }
        
        public void SetPosition(Vector3 value)
        {
            _stats.position = value;
        }
        
        public void SetRotation(float value)
        {
            _stats.rotation = value;
        }


        public void WriteStatsFromSave(Save save)
        {
            _stats.energy = save.playerEnergy;
            _stats.health = save.playerHealth;
            _stats.points = save.playerPoints;
            _stats.rang = save.playerRang;

            _stats.position = save.playerPosition;
            _stats.rotation = save.playerRotation;
        }
    }
}