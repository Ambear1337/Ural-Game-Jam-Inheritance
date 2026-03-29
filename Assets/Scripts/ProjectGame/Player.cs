using System;
using Sisus.Init;
using UnityEngine;

namespace ProjectGame
{
    [Service(FindFromScene = true)]
    public class Player: MonoBehaviour
    {
        public delegate void CoinsCountChanged();
        public event CoinsCountChanged OnCoinsCountChanged;
        
        [SerializeField]
        private PlayerInventory _inventory;
        public PlayerInventory Inventory => _inventory;

        [SerializeField] private int _startCoinsCount = 20;
        
        private int _coins;
        public int Coins => _coins;

        private void Awake()
        {
            _coins = _startCoinsCount;
            OnCoinsCountChanged?.Invoke();
        }

        public void AddCoins(int amount)
        {
            _coins += amount;
            
            OnCoinsCountChanged?.Invoke();
        }

        public bool TryToSubtractCoins(int amount)
        {
            if (_coins >= amount)
            {
                _coins -= amount;
                OnCoinsCountChanged?.Invoke();
                return true;
            }
            
            return false;
        }
    }
}
