﻿using System.Collections.Generic;
using UnityEngine;
using Windows;
using Core;

namespace Managers
{
    public class WindowManager : MonoBehaviour
    {
        [SerializeField] private MainWindowView _mainWindowView = null;
        [SerializeField] private InventoryWindowView _inventoryWindowView = null;
        
    
        [SerializeField] private MainWindowPresenter _mainWindowPresenter = null;
        [SerializeField] private InventoryWindowPresenter _inventoryWindowPresenter = null;

        private List<WindowPresenter> _panels;


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

        private void Start()
        {
            UpdatePanelsVisibility();
        }

        private void UpdatePanelsVisibility()
        {
            for (var i = 0; i < _panels.Count; i++)
            {
                if (i == Game.instance.currentPanel)
                {
                    _panels[i].Show();
                }
                else
                {
                    _panels[i].Hide();
                }
            }
        }

        private void OnDestroy()
        {
            //Game.instance.Loose(UpdatePanelsVisibility);
        }
    }
}