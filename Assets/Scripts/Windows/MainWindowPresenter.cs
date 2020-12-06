using Core;

namespace Windows
{
    public class MainWindowPresenter : WindowPresenter
    {
        protected override WindowView.Panel GetPresenterId()
        {
            return WindowView.Panel.Main;
        }
        
        public void OnInventoryButtonClick()
        {
            TryChangePanel(WindowView.Panel.Inventory);
        }
    }
}