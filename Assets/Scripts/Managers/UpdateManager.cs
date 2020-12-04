using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Core;

namespace Managers
{
    [CreateAssetMenu(fileName = "ManagerUpdate", menuName = "Managers/ManagerUpdate")]
    public class UpdateManager : ManagerBase, IAwake
    {
        private List<ITick> ticks = new List<ITick>();
        private List<ITickFixed> ticksFixes = new List<ITickFixed>();
        private List<ITickLate> ticksLate = new List<ITickLate>();


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
                    mngUpdate.ticks.Add(tick);
                    break;
                case ITickFixed @fixed:
                    mngUpdate.ticksFixes.Add(@fixed);
                    break;
                case ITickLate late:
                    mngUpdate.ticksLate.Add(late);
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
                    mngUpdate.ticks.Remove(tick);
                    break;
                case ITickFixed @fixed:
                    mngUpdate.ticksFixes.Remove(@fixed);
                    break;
                case ITickLate late:
                    mngUpdate.ticksLate.Remove(late);
                    break;
            }
        }


        public void Tick()
        {
            foreach (var t in ticks)
            {
                t.Tick();
            }
        }

        public void TickFixed()
        {
            foreach (var t in ticksFixes)
            {
                t.TickFixed();
            }
        }

        public void TickLate()
        {
            foreach (var t in ticksLate)
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