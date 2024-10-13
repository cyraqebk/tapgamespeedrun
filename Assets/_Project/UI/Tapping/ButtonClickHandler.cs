using UnityEngine;
using UnityEngine.EventSystems;
using Core.Tappings;
using Core.Setting;
using System.Collections;

namespace UI.Tappings
{
    public class ButtonClickHandler : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private SoftCurrency softCurrency;
        [SerializeField] private Settings settings;
        [SerializeField] private LevelUpgrade levelUpgrade;

        private Vector3 originalScale; // Хранит исходный размер кнопки

        private void Start()
        {
            // Сохраняем исходный размер кнопки
            originalScale = transform.localScale;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (Input.touchCount <= 3)
            {
                softCurrency.CurrencyIncrease(levelUpgrade.GetTheSpeed(levelUpgrade.CurrenLevel.Value));
                StartCoroutine(AnimateButton());
            }
        }

        private IEnumerator AnimateButton()
        {
            Vector3 targetScaleSmall = originalScale * 0.8f; // Уменьшаем до 60% от оригинала
            Vector3 targetScaleLarge = originalScale * 1.15f; // Увеличиваем до 110% от оригинала
            float duration = 0.1f; // Длительность каждой фазы анимации
            float elapsed = 0f;

            // Фаза 1: Плавно уменьшаем размер
            while (elapsed < duration)
            {
                transform.localScale = Vector3.Lerp(originalScale, targetScaleSmall, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;
            }

            // Устанавливаем уменьшенный размер
            transform.localScale = targetScaleSmall;

            // Фаза 2: Плавно увеличиваем до большего размера
            elapsed = 0f;
            while (elapsed < duration)
            {
                transform.localScale = Vector3.Lerp(targetScaleSmall, targetScaleLarge, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;
            }

            // Устанавливаем увеличенный размер
            transform.localScale = targetScaleLarge;

            // Фаза 3: Плавно возвращаемся к оригинальному размеру
            elapsed = 0f;
            while (elapsed < duration)
            {
                transform.localScale = Vector3.Lerp(targetScaleLarge, originalScale, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;
            }

            // Устанавливаем окончательный размер (нормальный)
            transform.localScale = originalScale;
        }
    }
}
