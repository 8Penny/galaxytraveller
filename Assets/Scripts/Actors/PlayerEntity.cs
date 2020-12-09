using Data;
using UnityEngine;
using Views;

namespace Actors {
    public class PlayerEntity : Entity {
        [SerializeField] private PlayerView _playerView;

        protected override void FillDataFromView() {
            var renderData = GetData(typeof(RBData)) as RBData;
            if (renderData == null) {
                return;
            }

            renderData.rigidbody = _playerView.rigidbody;
        }
    }
}