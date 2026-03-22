using Sisus.Init;
using UnityEngine;

namespace ProjectGame.UI.Debug
{
    public class AddCoinsButton: MonoBehaviour<Player>
    {
        private Player _player;

        [SerializeField] private int _coinsAmount;
    
        protected override void Init(Player argument)
        {
            _player = argument;
        }

        public void AddCoins()
        {
            _player.AddCoins(_coinsAmount);
        }
    }
}
