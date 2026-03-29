using Sisus.Init;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ProjectGame.Buttons
{
    public abstract class MenuButtonLeftClickBase : MonoBehaviour<SoundEffectsSource>, ISubmitHandler, IPointerClickHandler
    {
        [SerializeField]
        protected AudioClip _soundEffect;

        [SerializeField] protected AudioSource _audioSource;
        
        public void OnSubmit(BaseEventData eventData)
        {
            PlaySound();
            FireEvent();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if(eventData == null || eventData.selectedObject == null)
                return;
            
            if(!eventData.selectedObject.Equals(gameObject))
                return;
            
            if(eventData is { button: PointerEventData.InputButton.Left })
                FireEvent();
        }
        
        public void PlaySound()
        {
            if (_audioSource && _soundEffect) _audioSource.PlayOneShot(_soundEffect);
        }

        protected abstract void FireEvent();
    }
}