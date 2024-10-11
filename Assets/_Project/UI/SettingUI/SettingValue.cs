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
        [SerializeField] private Settings settings; // Ссылка на настройки
        [SerializeField] private TMP_Text value; // Текст для отображения состояния звука
        [SerializeField] private ControlMenu controlMenu; // Ссылка на класс управления меню

        private void Start() 
        {
            UpdateValueText(); // Обновляем текст при старте
            LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged; // Подписка на изменения языка
        }

        private void OnDestroy()
        {
            LocalizationSettings.SelectedLocaleChanged -= OnLocaleChanged; // Отписка от изменений языка
        }

        private void OnLocaleChanged(Locale locale)
        {
            UpdateValueText(); // Обновляем текст при изменении языка
        }

        private void UpdateValueText()
        {
            var currentLocale = LocalizationSettings.SelectedLocale; // Получаем текущую локаль
            if (currentLocale.Identifier.Code == "ru")
            {
                value.text = settings.sound ? "Да" : "Нет"; // Текст на русском
            }
            else
            {
                value.text = settings.sound ? "Yes" : "No"; // Текст на английском
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            controlMenu.ControlsSound(); // Переключаем состояние звука
            UpdateValueText(); // Обновляем текст после изменения
        }
    }
}
