using UnityEngine;

namespace Windows
{
    public class InventoryWindowPresenter : WindowPresenter
    {
        protected override WindowView.Panel GetPresenterId()
        {
            return WindowView.Panel.Inventory;
        }
        public void OnCloseButtonClick()
        {
            TryClosePanel();
        }
    }
}