using UnityEngine;
using UnityEngine.EventSystems;
using Core.Setting;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace UI.Setting
{
    public class SettingVibration : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private LocalizedString _localizationString;
        [SerializeField] private Settings settings;
        [SerializeField] private TMP_Text vibration;

        private void Start() 
        {
            // Инициализация текста в зависимости от текущего языка
            UpdateVibrationText();
            // Подписка на событие изменения языка
            LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;
        }

        private void OnDestroy()
        {
            // Отписка от события при уничтожении объекта
            LocalizationSettings.SelectedLocaleChanged -= OnLocaleChanged;
        }

        private void OnLocaleChanged(Locale locale)
        {
            // Обновляем текст при изменении языка
            UpdateVibrationText();
        }

        private void UpdateVibrationText()
        {
            // Получаем текущую локализацию
            var currentLocale = LocalizationSettings.SelectedLocale;
            // Устанавливаем текст в зависимости от локализации
            if (currentLocale.Identifier.Code == "ru")
            {
                vibration.text = settings.vbr ? "Да" : "Нет";
            }
            else
            {
                vibration.text = settings.vbr ? "Yes" : "No";
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            // Переключаем состояние вибрации
            settings.vbr = !settings.vbr;
            UpdateVibrationText(); // Обновляем текст после изменения
        }
    }
}
