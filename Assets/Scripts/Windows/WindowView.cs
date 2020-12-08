using System;
using Core;
using UnityEngine;
using Utils;

namespace Windows
{
    public class WindowView<T>: MonoBehaviour where T : WindowPresenter 
    {
        [SerializeField] private GameObject _panelGO = null;
        protected T _presenter;
        

        public void AddPresenter(T presenter)
        {
            _presenter = presenter;
        }

        private void OnEnable()
        {
            _presenter.Bind(OnChanged);
        }

        private void OnDisable()
        {
            _presenter.Loose(OnChanged);
        }

        protected virtual void OnChanged()
        {
            _panelGO.TrySetActive(_presenter.isVisible);
        }

    }
}