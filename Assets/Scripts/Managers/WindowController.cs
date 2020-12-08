using System;
using System.Collections.Generic;
using UnityEngine;
using Windows;
using Core;

namespace Managers
{
    public class WindowController : MonoBehaviour
    {
        [SerializeField] private MainWindowView _mainWindowView = null;
        [SerializeField] private InventoryWindowView _inventoryWindowView = null;
        
    
        [SerializeField] private MainWindowPresenter _mainWindowPresenter = null;
        [SerializeField] private InventoryWindowPresenter _inventoryWindowPresenter = null;

        private List<WindowPresenter> _panels;
        private Panel _currentPanel;
        
        private void Awake()
        {
            _mainWindowView.AddPresenter(_mainWindowPresenter);
            _inventoryWindowView.AddPresenter(_inventoryWindowPresenter);
            
            _panels = new List<WindowPresenter>()
            {
                _mainWindowPresenter,
                _inventoryWindowPresenter
            };
        }

        private void OnEnable()
        {
            _mainWindowPresenter.Bind(ChangePanel);
            _inventoryWindowPresenter.Bind(ChangePanel);
        }

        private void Start()
        {
            UpdatePanelsVisibility();
        }

        private void UpdatePanelsVisibility()
        {
            var currentPanel = (int) _currentPanel;
            for (var i = 0; i < _panels.Count; i++)
            {
                if (i == currentPanel)
                {
                    _panels[i].Show();
                }
                else
                {
                    _panels[i].Hide();
                }
            }
        }

        private void OnDisable()
        {
            _mainWindowPresenter.Loose(ChangePanel);
            _inventoryWindowPresenter.Loose(ChangePanel);
        }

        private void ChangePanel(Panel ind)
        {
            _currentPanel = ind;
            UpdatePanelsVisibility();
        }
    }
}