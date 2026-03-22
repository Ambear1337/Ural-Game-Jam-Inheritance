using System;
using Sisus.Init;
using UnityEngine;
using TMPro;

namespace ProjectGame.UI
{
    [Service(FindFromScene = true)]
    public class CoinsUI: MonoBehaviour<Player>
    {
        [SerializeField] private TextMeshProUGUI _coinsText;

        private Player _player;

        private void OnEnable()
        {
            _player.OnCoinsCountChanged += UpdateCoinsText;
        }

        private void OnDestroy()
        {
            _player.OnCoinsCountChanged -= UpdateCoinsText;
        }
        
        protected override void Init(Player argument)
        {
            _player = argument;
        }

        protected override void OnAwake()
        {
            base.OnAwake();
            
            UpdateCoinsText();
        }

        private void UpdateCoinsText()
        {
            _coinsText.text = _player.Coins.ToString();
        }
    }
}
