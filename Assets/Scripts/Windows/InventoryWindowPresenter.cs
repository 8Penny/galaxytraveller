using UnityEngine;

namespace Windows
{
    public class InventoryWindowPresenter : WindowPresenter
    {
        protected override Panel GetPresenterId()
        {
            return Panel.Inventory;
        }
        public void OnCloseButtonClick()
        {
            TryClosePanel();
        }
    }
}