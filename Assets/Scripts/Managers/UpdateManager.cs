using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Core;

namespace Managers
{
    [CreateAssetMenu(fileName = "ManagerUpdate", menuName = "Managers/ManagerUpdate")]
    public class UpdateManager : BaseManager, IAwake
    {
        private List<ITick> _ticks = new List<ITick>();
        private List<ITickFixed> _ticksFixes = new List<ITickFixed>();
        private List<ITickLate> _ticksLate = new List<ITickLate>();


        public static void AddTo(object updatable)
        {
            var mngUpdate = GameCore.Get<UpdateManager>();
            if (mngUpdate == null)
            {
                return;
            }
            switch (updatable)
            {
                case ITick tick:
                    mngUpdate._ticks.Add(tick);
                    break;
                case ITickFixed @fixed:
                    mngUpdate._ticksFixes.Add(@fixed);
                    break;
                case ITickLate late:
                    mngUpdate._ticksLate.Add(late);
                    break;
            }
        }

        public static void RemoveFrom(object updatable)
        {
            var mngUpdate = GameCore.Get<UpdateManager>();
            if (mngUpdate == null)
            {
                return;
            }
            switch (updatable)
            {
                case ITick tick:
                    mngUpdate._ticks.Remove(tick);
                    break;
                case ITickFixed @fixed:
                    mngUpdate._ticksFixes.Remove(@fixed);
                    break;
                case ITickLate late:
                    mngUpdate._ticksLate.Remove(late);
                    break;
            }
        }


        public void Tick()
        {
            foreach (var t in _ticks)
            {
                t.Tick();
            }
        }

        public void TickFixed()
        {
            foreach (var t in _ticksFixes)
            {
                t.TickFixed();
            }
        }

        public void TickLate()
        {
            foreach (var t in _ticksLate)
            {
                t.TickLate();
            }
        }


        public void OnAwake()
        {
            GameObject.Find("Main").AddComponent<UpdateManagerComponent>().Setup(this);
        }
    }
}