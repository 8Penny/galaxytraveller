using Core;
using UnityEngine;

namespace Windows
{
    public class WindowPresenter : MonoBehaviour
    {
        public delegate void ChangeEvent();
        private event ChangeEvent Changed;

        private bool _isVisible;
        public bool isVisible => _isVisible;

        public void Bind(ChangeEvent function)
        {
            Changed += function;
        }

        public void Loose(ChangeEvent function)
        {
            Changed -= function;
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
                
        public void OnCloseButtonClick()
        {
        }
    }
}