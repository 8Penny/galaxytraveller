using Data;
using UnityEngine;
using Views;

namespace Actors
{
    public class PlayerActor: Actor
    {
        [SerializeField] private PlayerView _playerView;
        protected override void FillDataFromView()
        {
            var renderData = GetData(typeof(RenderData)) as RenderData;
            if (renderData == null)
            {
                return;
            }

            renderData.rigidbody = _playerView.rigidbody;
            renderData.transform = _playerView.transform;
            renderData.boxCollider = _playerView.boxCollider;
        }
    }
}