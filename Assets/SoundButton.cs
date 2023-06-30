using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class SoundButton : MonoBehaviour
    {
        public Sprite MuteSprite, UnMuteSprite;

        private Button      _button;
        public  AudioSource AudioSource;

        private void OnEnable()
        {
            _button = GetComponent<Button>();
            if (AudioSource.mute)
            {
                _button.image.sprite = MuteSprite;
            }
            else
            {
                _button.image.sprite = UnMuteSprite;
            }
        }

        public void ButtonClicked()
        {
            AudioSource.mute = !AudioSource.mute;
            if (AudioSource.mute)
            {
                _button.image.sprite = MuteSprite;
            }
            else
            {
                _button.image.sprite = UnMuteSprite;
            }
        }
    }
}