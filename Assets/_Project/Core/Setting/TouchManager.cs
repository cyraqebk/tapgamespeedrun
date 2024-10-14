using UnityEngine;

namespace Core.Setting
{
    public class TouchManager : MonoBehaviour
    {
        private int maxTouches = 2;

        void Update()
        {
            // Ограничиваем касания, если их больше 2
            if (Input.touchCount > maxTouches)
            {
                Debug.LogWarning("Too many touches! Only first two will be processed.");
                return; // Полностью блокируем обработку событий, если касаний больше 2
            }

            // Обрабатываем только два касания или меньше
            for (int i = 0; i < Mathf.Min(Input.touchCount, maxTouches); i++)
            {
                Touch touch = Input.GetTouch(i);

                // Ваша логика обработки касаний
                if (touch.phase == TouchPhase.Began)
                {
                    Debug.Log($"Touch {i + 1} began at position {touch.position}");
                }
                else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    Debug.Log($"Touch {i + 1} is active at position {touch.position}");
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    Debug.Log($"Touch {i + 1} ended");
                }
            }
        }
    }
}
