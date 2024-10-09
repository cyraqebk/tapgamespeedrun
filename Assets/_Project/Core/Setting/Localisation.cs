using UnityEngine;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;

namespace Core.Setting
{
    public class Localisation : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private LocalizedString _localizationString;

        private void OnEnable()
        {
            _localizationString.StringChanged += OnStringChange;
            UpdateText(); // Вызываем обновление текста при активации
        }

        private void OnDisable()
        {
            _localizationString.StringChanged -= OnStringChange;
        }

        private void UpdateText()
        {
            // Проверка на наличие локализованного значения перед его использованием
            if (_localizationString != null)
            {
                string localizedValue = _localizationString.GetLocalizedString();
                OnStringChange(localizedValue);
            }
            else
            {
                Debug.LogWarning("[Localisation]: LocalizedString is null.");
            }
        }

        private void OnStringChange(string localizedValue)
        {
            if (_text != null)
            {
                _text.text = localizedValue;
            }
            else
            {
                Debug.LogWarning("[Localisation]: TMP_Text is null.");
            }
        }
    }
}
