using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class BallButton : MonoBehaviour
    {
        public Sprite     BallSprite;
        public GameObject SelectedText;
        public GameObject DefaultText;

        private Button _button;

        public int RequiredScore;


        private void OnEnable()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonClicked);
            GameManager.ChangePlayer += OnBallChanged;
        }

        private void OnDisable()
        {
            GameManager.ChangePlayer -= OnBallChanged;
            _button.onClick.RemoveListener(OnButtonClicked);
        }

        private void OnBallChanged(Sprite obj)
        {
            if (obj != BallSprite)
            {
                if (DefaultText)
                {
                    DefaultText.SetActive(true);
                }

                if (SelectedText)
                {
                    SelectedText.SetActive(false);
                }
            }
        }

        private void OnButtonClicked()
        {
            if (GameManager.Score >= RequiredScore)
            {
                if (SelectedText)
                {
                    SelectedText.SetActive(true);
                }

                if (DefaultText)
                {
                    DefaultText.SetActive(false);
                }

                GameManager.ChangePlayer?.Invoke(BallSprite);
            }
        }
    }
}