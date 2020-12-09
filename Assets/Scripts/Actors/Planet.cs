using Data;
using UnityEngine;
using Views;
using Views.Earth;

namespace Actors
{
    public class Planet : Entity
    {
        [SerializeField] private PlanetView _planetView;
        protected override void FillDataFromView()
        {
            var eData = GetData(typeof(PlanetData)) as PlanetData;
            if (eData == null)
            {
                return;
            }
            eData.transform = _planetView.transform;
        }
    }
}