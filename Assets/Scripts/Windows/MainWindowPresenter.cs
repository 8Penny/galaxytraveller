using Core;

namespace Windows
{
    public class MainWindowPresenter : WindowPresenter
    {
        public void OnInventoryButtonClick()
        {
            Game.instance.SetCurrentPanel((int)WindowView.Panel.Inventory);
        }
    }
}