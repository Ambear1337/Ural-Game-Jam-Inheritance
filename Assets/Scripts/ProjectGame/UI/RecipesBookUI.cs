using System;
using System.Collections.Generic;
using ProjectGame.Combinations;
using Sisus.Init;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace ProjectGame.UI
{
    public class RecipesBookUI: MonoBehaviour<RecipesBook>
    {
        [SerializeField] private GameObject _recipesBookPanel;
        [SerializeField] private GameObject _typesPanel;
        [SerializeField] private GameObject _elementsPanel;
        [SerializeField] private GameObject _typesPanelButton;
        [SerializeField] private GameObject _elementsPanelButton;

        [SerializeField] private List<TypeRecipeUI> _typesRecipes;
        [SerializeField] private List<ElementRecipeUI> _elementsRecipes;
        
        private RecipesBook _recipesBook;
        private bool _isOpen;
        
        protected override void Init(RecipesBook book)
        {
            _recipesBook = book;
        }

        public void ToggleRecipesBook()
        {
            _recipesBookPanel.SetActive(!_isOpen);
            _typesPanelButton.SetActive(!_isOpen);
            _elementsPanelButton.SetActive(!_isOpen);
            _isOpen = !_isOpen;
            
            UpdateUI();
        }

        public void ActivateTypesPanel()
        {
            if (_elementsPanel != null)
                _elementsPanel.SetActive(false);
            
            if (_typesPanel != null)
                _typesPanel.SetActive(true);
            
            UpdateUI();
        }

        public void ActivateElementsPanel()
        {
            if (_typesPanel != null)
                _typesPanel.SetActive(false);
    
            if (_elementsPanel != null)
                _elementsPanel.SetActive(true);
            
            UpdateUI();
        }

        private void UpdateUI()
        {
            if (_isOpen)
            {
                if (_typesPanel.activeSelf)
                {
                    UpdateTypesPanelUI();
                }

                if (_elementsPanel.activeSelf)
                {
                    UpdateElementsPanelUI();
                }
            }
        }

        private void UpdateTypesPanelUI()
        {
            for (int i = 0; i < _typesRecipes.Count; i++)
            {
                for (int j = 0; j < _recipesBook.KnownTypeRecipes.Count; j++)
                {
                    if (_typesRecipes[i].CreatureType == _recipesBook.KnownTypeRecipes[j].Result)
                    {
                        _typesRecipes[i].gameObject.SetActive(true);
                    }
                }
            }
        }

        private void UpdateElementsPanelUI()
        {
            for (int i = 0; i < _elementsRecipes.Count; i++)
            {
                for (int j = 0; j < _recipesBook.KnownElementRecipes.Count; j++)
                {
                    if (_elementsRecipes[i].CreatureElement == _recipesBook.KnownElementRecipes[j].Result)
                    {
                        _elementsRecipes[i].gameObject.SetActive(true);
                    }
                }
            }
        }
    }
}