namespace Actors {
    public class OneOffInteractableActor : InteractableActor {
        protected override void OnEnable() {
            base.OnEnable();
            _interactableData.BindOnFinished(OnFinish);
        }

        protected override void OnDisable() {
            base.OnDisable();
            _interactableData.LooseOnFinished(OnFinish);
        }

        private void OnFinish() {
            _interactableMng.RemoveInteractable(_interactableData);
            Destroy(gameObject);
        }
    }
}