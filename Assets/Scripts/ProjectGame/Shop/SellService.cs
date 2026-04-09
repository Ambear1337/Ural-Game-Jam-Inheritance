using System;
using ProjectGame.UI;
using Sisus.Init;
using UnityEngine;

namespace ProjectGame.Shop
{
    [Service(FindFromScene = true)]
    public class SellService: MonoBehaviour<CreatureSpawner, HuntersShop>
    {
        [SerializeField] private SellInventory _inventory;

        private CreatureSpawner _spawner;
        private HuntersShop _huntersShop;
        
        protected override void Init(CreatureSpawner argument, HuntersShop huntersShop)
        {
            _spawner = argument;
            _huntersShop = huntersShop;
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