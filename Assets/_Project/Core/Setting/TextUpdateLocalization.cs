using UnityEngine;
using TMPro;
using UnityEngine.Localization.Components;
using UnityEngine.Localization;

namespace Core.Setting
{
    public class TextUpdateLocalization : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private LocalizedString _localizationString;

        private void Awake()
        {
            ValidateText();
        }

        private void OnEnable()
        {
            _localizationString.StringChanged += OnStrignChange;

        }
        private void OnDisable()
        {
            _localizationString.StringChanged -= OnStrignChange;
        }
        private void OnStrignChange(string _localizedString) => ValidateText();
        private void ValidateText()
        {
            _text.text = _localizationString.GetLocalizedString();
        }
    }
}
