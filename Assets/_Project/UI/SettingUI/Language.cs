using UnityEngine;
using UnityEngine.EventSystems;
using Core.Setting;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using Core.ReactiveFields;
using UI.Animation;

namespace UI.SettingUI
{
    public class Language : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Settings settings;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private ControlMenu controlMenu;
        [SerializeField] private AnimationButton animationButton;
        private Vector3 originalScale;

        private void OnEnable()
        {
            controlMenu.Loge.Changed += CurrencyText;
            controlMenu.SwitchLanguage();
            UpdateValueText();
        }

        private void OnDisable()
        {
            controlMenu.Loge.Changed += CurrencyText;
        }

        private void CurrencyText(bool oldValue, bool newValue)
        {
            controlMenu.SwitchLanguage();
            UpdateValueText();
        }
        private void Start() 
        {
            originalScale = transform.localScale;
            UpdateValueText();
            LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;
        }

        private void OnDestroy()
        {
            LocalizationSettings.SelectedLocaleChanged -= OnLocaleChanged;
        }

        private void OnLocaleChanged(Locale locale)
        {
            UpdateValueText();
        }

        private void UpdateValueText()
        {
            var currentLocale = LocalizationSettings.SelectedLocale;

            // Если локаль русская, то выводим "РУ" или "АНГЛ" в зависимости от состояния loge
            if (currentLocale.Identifier.Code == "ru")
            {
                _text.text = controlMenu.Loge.Value ? "РУ" : "АНГЛ"; 
            }
            else
            {
                _text.text = controlMenu.Loge.Value ? "RU" : "ENG"; 
            }
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            controlMenu.Loge.Value = !controlMenu.Loge.Value; // Переключаем значение
            StartCoroutine(animationButton.AnimateButton(transform, originalScale));
            UpdateValueText(); // Обновляем текст после изменения состояния
        }
    }
}
