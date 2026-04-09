using System.Collections.Generic;
using Sisus.Init;
using UnityEngine;

namespace ProjectGame.Shop
{
    [Service(FindFromScene = true)]
    public class HuntersShop: MonoBehaviour<Player, SellService>
    {
        private Player _player;
        private SellService _sellService;

        
        
        protected override void Init(Player argument, SellService sellService)
        {
            _player = argument;
            _sellService = sellService;
        }
        
        public void BuyCreature(ShopCell cell)
        {
            _player.TryToSubtractCoins(100);
        }

        public void SellCreature(Creature creature)
        {
            _player.AddCoins(1);
            _sellService.SellCreature(creature);
        }
    }
}