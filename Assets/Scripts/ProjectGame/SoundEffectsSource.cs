using System;
using Sisus.Init;
using UnityEngine;

namespace ProjectGame
{
    [Service(Instantiate = true)]
    public class SoundEffectsSource: MonoBehaviour
    {
        private AudioSource _audioSource;
        private AudioClip _soundEffect;

        private void Awake()
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }

        public void SetSoundEffect(AudioClip soundEffect)
        {
            _soundEffect = soundEffect;
        }

        private void PlayAudio()
        {
            if (_audioSource && _soundEffect) _audioSource.PlayOneShot(_soundEffect);
        }
    }
}