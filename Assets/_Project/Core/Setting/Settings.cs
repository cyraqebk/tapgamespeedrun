using UnityEngine;
using UnityEngine.UI;
using Core.Json;
using System.Collections;

namespace Core.Setting
{
    public class Settings : MonoBehaviour
    {
        public AudioSource backgroundMusic;
        public AudioSource EggSound;
        public AudioSource _successfulPurchase;
        public AudioSource _unsuccessfulPurchase;
        public AudioSource _collectingCoins;
        public AudioSource _button;
        public bool vbr = true; // Вибрация включена по умолчанию
        public bool sound = true; // Звук включен по умолчанию
        public bool sound2 = true;

        private void Start()
        {
            // Загрузка состояния звука из сохранений
            sound = SaveManager.Load("sound", false);
            sound2 = SaveManager.Load("sound2", true);

            if (sound)
            {
                // Воспроизводим музыку, если звук включен
                backgroundMusic.Play();
                backgroundMusic.volume = 0.1f; // Устанавливаем громкость
            }
            else
            {
                // Выключаем звук, если он отключен
                backgroundMusic.volume = 0;
            }
            if (sound2)
            {
                EggSound.volume = 0.5f;
                _successfulPurchase.volume = 0.5f;
                _unsuccessfulPurchase.volume = 0.5f;
                _collectingCoins.volume = 0.5f;
                _button.volume = 0.5f;
            }
            else
            {
                EggSound.volume = 0;
                _successfulPurchase.volume = 0;
                _unsuccessfulPurchase.volume = 0;
                _collectingCoins.volume = 0;
                _button.volume = 0;
            }
        }

        // Отключение звука
        public void MuteSound()
        {
            backgroundMusic.volume = 0; // Отключаем звук
            sound = false; // Фиксируем состояние звука
            SaveManager.Save("sound", sound); // Сохраняем состояние
        }

        // Включение звука
        public void UnmuteSound()
        {
            backgroundMusic.volume = 0.1f; // Включаем звук
            sound = true; // Фиксируем состояние звука
            SaveManager.Save("sound", sound); // Сохраняем состояние
        }

        public void OnSound()
        {
            EggSound.volume = 0.5f;
            _successfulPurchase.volume = 0.5f;
            _unsuccessfulPurchase.volume = 0.5f;
            _collectingCoins.volume = 0.5f;
            _button.volume = 0.5f;
            sound2 = true;
            SaveManager.Save("sound2", sound2);
        }

        public void OffSound()
        {
            EggSound.volume = 0;
            _successfulPurchase.volume = 0;
            _unsuccessfulPurchase.volume = 0;
            _collectingCoins.volume = 0;
            _button.volume = 0;
            sound2 = false;
            SaveManager.Save("sound2",sound2);
        }

        // Вибрация на 0.1 секунды
        public void VibrationPulse()
        {
            if (vbr)
            {
                Debug.Log("Сработала вибрация");
                StartCoroutine(VibrateForDuration(0.1f)); // Запускаем вибрацию
            }
        }

        // Короутина для вибрации
        private IEnumerator VibrateForDuration(float duration)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            Handheld.Vibrate(); // Вибрация только на Android
#endif
            yield return new WaitForSeconds(duration); // Ждём указанную продолжительность
        }
    }
}
