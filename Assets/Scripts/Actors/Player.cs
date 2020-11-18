using UnityEngine;

namespace Actors
{
    public class Player : Creature
    {
        private uint _points;
        private uint _rang;
        private float _energy;

        public uint points => _points;
        public uint rang => _rang;
        public float energy => _energy;

        public void SetPoints(uint value)
        {
            _points = value;
        }

        public void SetEnergy(float value)
        {
            _energy = value;
        }

        public void SetRang(uint value)
        {
            _rang = value;
        }
    }
}