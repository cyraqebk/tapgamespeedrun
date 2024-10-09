using UnityEngine;
using TMPro;
using UnityEngine.Localization.Components;
using UnityEngine.Localization;

namespace Core.Setting
{
    public class LocalisationWithArgument : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private LocalizedString _localizationString;
        
        // Поле для передачи значения
        [SerializeField] private string argumentValue; // Можно передавать int, float, и т.д., если нужно

        private void OnEnable()
        {
            _localizationString.StringChanged += OnStringChange;
            // Передача аргумента в локализованную строку
            _localizationString.Arguments = new object[] { argumentValue };
            OnStringChange(_localizationString.GetLocalizedString());
        }

        private void OnDisable()
        {
            _localizationString.StringChanged -= OnStringChange;
        }

        private void OnStringChange(string localizedValue)
        {
            _text.text = localizedValue;
        }

        // Метод для обновления аргумента
        public void UpdateArgument(string newArgument)
        {
            argumentValue = newArgument;
            _localizationString.Arguments = new object[] { argumentValue };
            OnStringChange(_localizationString.GetLocalizedString());
        }
    }
}
