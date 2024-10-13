using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

namespace UI.Animation
{
    public class FloatingText : MonoBehaviour
    {
    private TMP_Text text; // Компонент текста (или TextMeshPro, если используется)
    private Vector3 startPos;
    private Color startColor;
    private float floatSpeed = 100f; // Скорость, с которой текст поднимается вверх
    private float fadeDuration = 1.5f; // Время исчезновения текста

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void Show(string message, Vector3 position)
    {
        text.text = message;
        startPos = position;
        transform.position = position;
        startColor = text.color;
        StartCoroutine(FlyUpAndFade());
    }

    private IEnumerator FlyUpAndFade()
    {
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            transform.position = Vector3.Lerp(startPos, startPos + Vector3.up * floatSpeed, elapsed / fadeDuration); // Движение вверх
            text.color = new Color(startColor.r, startColor.g, startColor.b, Mathf.Lerp(1f, 0f, elapsed / fadeDuration)); // Постепенное исчезновение
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Возвращаем объект в пул после анимации
        ObjectPool pool = Object.FindAnyObjectByType<ObjectPool>();
        pool.ReturnObject(gameObject);
    }
    }
}
