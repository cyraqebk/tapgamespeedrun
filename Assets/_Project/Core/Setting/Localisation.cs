using UnityEngine;
using TMPro;
using UnityEngine.Localization.Components;
using UnityEngine.Localization;

namespace Core.Setting
{
    public class Localisation : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private LocalizedString _localizationString;

        private void OnEnable()
        {
            _localizationString.StringChanged += OnStringChange;
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
    }
}
