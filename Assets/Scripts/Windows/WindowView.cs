using System;
using Core;
using UnityEngine;

namespace Windows
{
    public class WindowView: MonoBehaviour
    {
        [SerializeField] private GameObject _panelGO;
        private WindowPresenter _presenter;

        public enum Panel
        {
            Main = 0,
            Inventory = 1
        }

        public void AddPresenter(WindowPresenter presenter)
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
            _panelGO.SetActive(_presenter.isVisible);
        }

    }
}