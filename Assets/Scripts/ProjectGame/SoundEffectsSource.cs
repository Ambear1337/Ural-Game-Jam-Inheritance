using System;
using Sisus.Init;
using UnityEngine;

namespace ProjectGame
{
    [Service(Instantiate = true)]
    public class SoundEffectsSource: MonoBehaviour
    {
        private AudioSource _audioSource;
        public AudioSource AudioSource => _audioSource;
        
        private void Awake()
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
            _audioSource.playOnAwake = false;
            _audioSource.volume = 0.5f;
        }
    }
}