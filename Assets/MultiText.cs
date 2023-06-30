using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class MultiText : MonoBehaviour
    {
        public string Eng, Bra;

        private TMP_Text _text;

        private void OnEnable()
        {
            _text                       =  GetComponent<TMP_Text>();
            _text.text                  =  GameManager.Language == "eng" ? Eng : Bra;
            GameManager.LanguageChanged += OnLanguageChanged;
        }

        private void OnLanguageChanged()
        {
            _text.text = GameManager.Language == "eng" ? Eng : Bra;
        }
    }
}