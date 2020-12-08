using System;
using UnityEngine;
using UnityEngine.UI;

namespace Windows
{
    public class InventoryWindowView : WindowView<InventoryWindowPresenter>
    {
        [SerializeField] private Button _useButton = null;
        
        public void OnCloseButtonClick()
        {
        }

        public void OnUseButtonClick()
        {
        }

    }
}