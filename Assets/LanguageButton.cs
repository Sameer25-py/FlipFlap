using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class LanguageButton : MonoBehaviour
    {
        private Button _button;

        private void OnEnable()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClicked);
        }

        private void OnClicked()
        {
            GameManager.Language = GameManager.Language == "eng" ? "bra" : "eng";
            GameManager.LanguageChanged?.Invoke();
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClicked);
        }
    }
}