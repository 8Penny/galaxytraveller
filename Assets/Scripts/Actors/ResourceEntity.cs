using Core;
using Managers;

namespace Actors {
    public class ResourceEntity : InteractableEntity {
        protected override void OnEnable() {
            base.OnEnable();
            _interactableData.BindOnFinished(OnFinish);
        }

        protected override void OnDisable() {
            base.OnDisable();
            _interactableData.LooseOnFinished(OnFinish);
        }

        protected override void OnFinish() {
            base.OnFinish();
            Destroy(gameObject);
        }
    }
}