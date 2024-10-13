using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;
using Core.ReactiveFields;
using Core.Json;

namespace Core.Setting
{
    public class ControlMenu : MonoBehaviour
    {
        [SerializeField] private Settings settings;
        [SerializeField] private GameInitializer _gameInitializer;
        private string currentLocale;
        [SerializeField] private ReactiveField<bool> loge = new ReactiveField<bool>(true);
        public ReactiveField<bool> Loge => loge;

        private void Start()
        {
            currentLocale = LocalizationSettings.SelectedLocale?.Identifier.Code ?? "ru";
            settings.vbr = SaveManager.Load("vbr", false);
            loge.Value = SaveManager.Load("loge", false);
            Debug.Log(" звук " + settings.sound + " язык " + loge.Value + " Вибрация " + settings.vbr);

            // Установка языка в зависимости от значения loge
            if (!loge.Value) // Если loge равно false
            {
                SetLanguage("en"); // Установите язык на английский
            }

            _gameInitializer.SubscribeToStopGame(OnStopGame);
        }

        private void OnDestroy()
        {
            if (_gameInitializer != null)
            {
                _gameInitializer.UnsubscribeFromStopGame(OnStopGame);
            }
        }

        private void OnStopGame()
        {
            SaveManager.Save("vbr", settings.vbr);
            SaveManager.Save("sound", settings.sound);
            SaveManager.Save("loge", loge.Value);
        }


        public void ControlsSound()
        {
            if (settings.sound)
            {
                settings.MuteSound();
            }
            else
            {
                settings.UnmuteSound();
            }
            // Убедитесь, что здесь нет изменения состояния вибрации
        }
        public void ControlVbr()
        {
            settings.vbr = !settings.vbr;
        }
        public void SwitchLanguage()
        {
            if (currentLocale == "en")
            {
                SetLanguage("ru"); // Переключаем на русский
            }
            else
            {
                SetLanguage("en"); // Переключаем на английский
            }
        }
        private void SetLanguage(string localeIdentifier)
        {
            Locale newLocale = LocalizationSettings.AvailableLocales.GetLocale(localeIdentifier);
            if (newLocale != null)
            {
                LocalizationSettings.SelectedLocale = newLocale;
                currentLocale = localeIdentifier;
            }
        }
    }
}
