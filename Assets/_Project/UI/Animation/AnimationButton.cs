using UnityEngine;
using System.Collections;

namespace UI.Animation
{
    public class AnimationButton : MonoBehaviour
    {
        private bool isAnimating = false; // Флаг анимации

        // Метод для запуска анимации, он принимает объект для анимации и его исходный масштаб
        public IEnumerator AnimateButton(Transform buttonTransform, Vector3 originalScale)
        {
            if (isAnimating)
                yield break; // Если анимация уже идет, ничего не делать

            isAnimating = true;

            float duration = 0.2f; // Длительность анимации
            float elapsed = 0f;

            // Анимация уменьшения и увеличения размера
            while (elapsed < duration)
            {
                buttonTransform.localScale = Vector3.Lerp(originalScale * 0.8f, originalScale, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;
            }

            buttonTransform.localScale = originalScale; // Возвращаем исходный размер
            isAnimating = false;
        }
    }
}
