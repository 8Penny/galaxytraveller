using System;
using Core;
using Data;
using Managers;

namespace Windows
{
    public class MainWindowPresenter : WindowPresenter {
        public bool isActivityButtonEnabled => _activityButtonVisibility;
        public string activityButtonText => _activityButtonText;
        
        private bool _activityButtonVisibility;
        private string _activityButtonText;
        
        private InteractableManager _interactableMng;
        protected override Panel GetPresenterId()
        {
            return Panel.Main;
        }

        private void Awake() {
            _interactableMng = GameCore.Get<InteractableManager>();
        }

        private void OnEnable() {
            _interactableMng.Bind(UpdateActivityButton);
        }

        private void UpdateActivityButton() {
            _activityButtonVisibility = _interactableMng.hasInteractable;
            _activityButtonText = _interactableMng.interactableType == InteractableType.Resource ? "Interact" : "Attack";
            
            Update();
        }

        public void OnInventoryButtonClick()
        {
            TryChangePanel(Panel.Inventory);
        }
        
        public void OnActivityButtonClick()
        {
            _interactableMng.Interact();
        }

        private void OnDisable() {
            _interactableMng.Loose(UpdateActivityButton);
        }
    }
}