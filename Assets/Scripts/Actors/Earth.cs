using Data;
using UnityEngine;
using Views;
using Views.Earth;

namespace Actors
{
    public class Earth : Actor
    {
        [SerializeField] private EarthView _earthView;
        protected override void FillDataFromView()
        {
            var eData = GetData(typeof(EarthData)) as EarthData;
            if (eData == null)
            {
                return;
            }
            eData.transform = _earthView.transform;
        }
    }
}