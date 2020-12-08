using UnityEngine;
using UnityEngine.UI;


namespace Windows
{
    public class MainWindowView : WindowView<MainWindowPresenter>
    {
        [SerializeField] private Button _inventoryButton = null;
        [SerializeField] private Button _builderButton = null;
        [SerializeField] private Button _activitykButton = null;
        [SerializeField] private Text _activitykButtonText;
        

        protected override void OnChanged() {
            base.OnChanged();
            _activitykButton.interactable = _presenter.isActivityButtonEnabled;
            _activitykButtonText.text = _presenter.activityButtonText;

        }
    }
}