using Core;
using UnityEngine;

namespace Windows
{
    public abstract class WindowPresenter : MonoBehaviour
    {
        public delegate void ChangePanelEvent(WindowView.Panel id);
        public delegate void ChangeEvent();
        public bool isVisible => _isVisible;
        private event ChangePanelEvent PanelChanged;
        private event ChangeEvent Changed;

        private bool _isVisible;

        protected abstract WindowView.Panel GetPresenterId();

        public void Bind(ChangeEvent function)
        {
            Changed += function;
        }

        public void Bind(ChangePanelEvent function)
        {
            PanelChanged += function;
        }

        public void Loose(ChangeEvent function)
        {
            Changed -= function;
        }
        
        public void Loose(ChangePanelEvent function)
        {
            PanelChanged -= function;
        }

        public void Show()
        {
            _isVisible = true;
            Update();
        }

        public void Hide()
        {
            _isVisible = false;
            Update();
        }

        protected void Update()
        {
            Changed?.Invoke();;
        }

        protected void TryChangePanel(WindowView.Panel id)
        {
            PanelChanged?.Invoke(id);
        }

        protected void TryClosePanel()
        {
            if (GetPresenterId() == WindowView.Panel.Main)
            {
                return;
            }

            TryChangePanel(WindowView.Panel.Main);
        }
    }
}