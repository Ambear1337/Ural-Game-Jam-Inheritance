using Sisus.Init;
using UnityEngine;

namespace ProjectGame
{
    [Service(FindFromScene = true)]
    public class Shop: MonoBehaviour<Player, SellService>
    {
        private Player _player;
        private SellService _sellService;

        private int _baseCreatureCost = 10;
        public int BaseCreatureCost => _baseCreatureCost;
        private int _hybridCreatureCost = 25;
        public int HybridCreatureCost => _hybridCreatureCost;
        
        protected override void Init(Player argument, SellService sellService)
        {
            _player = argument;
            _sellService = sellService;
        }
        
        public void BuyCreature()
        {
            
        }

        public void SellCreature(Creature creature)
        {
            _player.AddCoins(creature.Cost);
            _sellService.SellCreature(creature);
        }
    }
}