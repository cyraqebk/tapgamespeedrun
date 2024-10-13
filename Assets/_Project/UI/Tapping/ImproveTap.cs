using UnityEngine;
using UnityEngine.EventSystems;
using UI.Animation; // Подключаем скрипт с анимацией
using Core.Tappings;
using Core.Setting;

namespace UI.Tappings
{
    public class ImproveTap : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private LevelUpgrade levelUpgrade; // Ссылка на ваш класс уровня
        [SerializeField] private SoftCurrency softCurrency; // Ссылка на ваш класс валюты
        [SerializeField] private AnimationButton animationButton; // Ссылка на класс анимации кнопки

        private Vector3 originalScale; // Хранит оригинальный масштаб кнопки

        private void Start()
        {
            // Сохраняем исходный размер кнопки
            originalScale = transform.localScale;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Button clicked");

            StartCoroutine(animationButton.AnimateButton(transform, originalScale));
            levelUpgrade.Improvement();
        }
    }
}
