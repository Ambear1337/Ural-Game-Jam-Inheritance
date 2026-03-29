using System;
using ProjectGame.UI;
using Sisus.Init;
using UnityEngine;

namespace ProjectGame
{
    [Service(FindFromScene = true)]
    public class SellService: MonoBehaviour<CreatureSpawner, Shop>
    {
        [SerializeField] private SellInventory _inventory;

        private CreatureSpawner _spawner;
        private Shop _shop;
        
        protected override void Init(CreatureSpawner argument, Shop shop)
        {
            _spawner = argument;
            _shop = shop;
        }

        public void SellCreature(Creature creature)
        {
            if (_inventory.Slots[0] != null)
            {
                _inventory.RemoveCreature(0);
                _inventory.RaiseInventoryChanged();
            }
        }
    }
}