using ProjectGame.Combinations;
using Sisus.Init;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace ProjectGame.UI
{
    public class RecipesBookUI: MonoBehaviour<RecipesBook>
    {
        [SerializeField] private GameObject _recipesBookPanel;
        
        private RecipesBook _recipesBook;
        private bool _isOpen;
        
        protected override void Init(RecipesBook book)
        {
            _recipesBook = book;
        }
        
        public void ToggleRecipesBook()
        {
            _recipesBookPanel.SetActive(!_isOpen);
            _isOpen = !_isOpen;
            
            UpdateUI();
        }

        private void UpdateUI()
        {
            if (_isOpen)
            {
                
            }
        }
    }
}