using UnityEngine;
using UnityEngine.UI;
using Core.Json;
using System.Collections;

namespace Core.Setting
{
    public class Settings : MonoBehaviour
    {
        public AudioSource backgroundMusic;
        public bool vbr = true; // Вибрация включена по умолчанию
        public bool sound = true; // Звук включен по умолчанию

        private void Start()
        {
            // Загрузка состояния звука из сохранений
            sound = SaveManager.Load("sound", false);

            if (sound)
            {
                // Воспроизводим музыку, если звук включен
                backgroundMusic.Play();
                AudioListener.volume = 1; // Устанавливаем громкость
            }
            else
            {
                // Выключаем звук, если он отключен
                AudioListener.volume = 0;
            }
        }

        // Отключение звука
        public void MuteSound()
        {
            Debug.Log("выключил звук");
            AudioListener.volume = 0; // Отключаем звук
            sound = false; // Фиксируем состояние звука
            SaveManager.Save("sound", sound); // Сохраняем состояние
        }

        // Включение звука
        public void UnmuteSound()
        {
            Debug.Log("Включил звук");
            AudioListener.volume = 1; // Включаем звук
            sound = true; // Фиксируем состояние звука
            SaveManager.Save("sound", sound); // Сохраняем состояние
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
