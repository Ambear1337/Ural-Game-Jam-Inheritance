using Sisus.Init;
using UnityEngine;

namespace ProjectGame.UI.Debug
{
    public class BuyCreatureButton: MonoBehaviour<Player, CreatureSpawner>
    {
        private Inventory _playerInventory;
        private Player _player;
        private CreatureSpawner _creatureSpawner;

        [SerializeField] private int _cost;
        
        protected override void Init(Player player, CreatureSpawner spawner)
        {
            _player = player;
            _playerInventory = _player.Inventory;
            _creatureSpawner = spawner;
        }
        
        public void BuyRandomCreature()
        {
            if (_player.TryToSubtractCoins(_cost))
            {
                _creatureSpawner.SpawnRandomCreature();
            }
        }
    }
}
