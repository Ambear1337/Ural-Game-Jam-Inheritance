using Sisus.Init;
using UnityEngine;

namespace ProjectGame
{
    [Service(Instantiate = true)]
    public class Shop: MonoBehaviour<Player>
    {
        private Player _player;
        
        protected override void Init(Player argument)
        {
            _player = argument;
        }
        
        public void BuyCreature()
        {
            
        }

        public void SellCreature(Creature creature)
        {
            _player.AddCoins(10);
        }
    }
}