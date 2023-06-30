using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class MultiTextImage : MonoBehaviour
    {
        [SerializeField] private Sprite eng, bra;

        private Image _image;

        private void OnEnable()
        {
            _image                      =  GetComponent<Image>();
            GameManager.LanguageChanged += OnChangeLanguageCalled;
            OnChangeLanguageCalled();
        }

        private void OnChangeLanguageCalled()
        {
            _image.sprite = GameManager.Language == "eng" ? eng : bra;
        }
    }
}