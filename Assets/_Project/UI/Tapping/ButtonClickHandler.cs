using UnityEngine;
using UnityEngine.EventSystems;
using Core.Tappings;
using Core.Setting;
using System.Collections;
using UI.Animation;

namespace UI.Tappings
{
    public class ButtonClickHandler : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private SoftCurrency softCurrency;
        [SerializeField] private Settings settings;
        [SerializeField] private LevelUpgrade levelUpgrade;
        [SerializeField] private ObjectPool textPool; // Пул для текстовых объектов
        [SerializeField] private Canvas canvas; // Canvas для UI элементов

        private Vector3 originalScale;

        private void Start()
        {
            originalScale = transform.localScale;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            audioSource.PlayOneShot(audioSource.clip);
            int addedValue = levelUpgrade.GetTheSpeed(levelUpgrade.CurrenLevel.Value);
            softCurrency.CurrencyIncrease(addedValue);
            ShowFloatingText("+" + addedValue.ToString(), eventData.position);
            StartCoroutine(AnimateButton());
        }

        private void ShowFloatingText(string text, Vector3 clickPosition)
        {
            // Получаем объект текста из пула
            GameObject floatingTextObj = textPool.GetObject();

            // Конвертируем позицию экрана в координаты Canvas
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, clickPosition, canvas.worldCamera, out localPoint);

            // Устанавливаем текст и анимацию
            floatingTextObj.GetComponent<FloatingText>().Show(text, canvas.transform.TransformPoint(localPoint));
        }

        private IEnumerator AnimateButton()
        {
            Vector3 targetScaleSmall = originalScale * 0.8f;
            Vector3 targetScaleLarge = originalScale * 1.15f;
            float duration = 0.1f;
            float elapsed = 0f;

            while (elapsed < duration)
            {
                transform.localScale = Vector3.Lerp(originalScale, targetScaleSmall, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;
            }

            transform.localScale = targetScaleSmall;

            elapsed = 0f;
            while (elapsed < duration)
            {
                transform.localScale = Vector3.Lerp(targetScaleSmall, targetScaleLarge, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;
            }

            transform.localScale = targetScaleLarge;

            elapsed = 0f;
            while (elapsed < duration)
            {
                transform.localScale = Vector3.Lerp(targetScaleLarge, originalScale, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;
            }

            transform.localScale = originalScale;
        }
    }
}
