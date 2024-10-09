using UnityEngine;
using UnityEngine.EventSystems;
using Core.Setting;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace UI.Setting
{
    public class SettingValue : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Settings settings;
        [SerializeField] private TMP_Text value;

        private void Start() 
        {
            // Инициализация текста в зависимости от текущего языка
            UpdateValueText();
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
            UpdateValueText();
        }

        private void UpdateValueText()
        {
            // Получаем текущую локализацию
            var currentLocale = LocalizationSettings.SelectedLocale;
            // Устанавливаем текст в зависимости от локализации
            if (currentLocale.Identifier.Code == "ru")
            {
                value.text = settings.vbr ? "Да" : "Нет";
            }
            else
            {
                value.text = settings.vbr ? "Yes" : "No";
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            // Переключаем состояние звука
            if (settings.vbr)
            {
                settings.MuteSound();
                settings.vbr = false;
            }
            else
            {
                settings.UnmuteSound();
                settings.vbr = true;
            }
            UpdateValueText(); // Обновляем текст после изменения
        }
    }
}
