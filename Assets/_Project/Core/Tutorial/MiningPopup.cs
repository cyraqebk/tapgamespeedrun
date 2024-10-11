using UnityEngine;
using UnityEngine.EventSystems;
public class MiningPopup : MonoBehaviour
{
    public GameObject PopupWindow;
    private void Start()
    {

        if (!PlayerPrefs.HasKey("HasShownTutorialMining"))
        {
            PopupWindow.SetActive(true);
        }
        else
        {
            // PopupWindow.SetActive(false);
        }
    }
    void Update()
    {
        if (Input.touchCount > 0) // Проверяем, есть ли касания на экране
        {
            Touch touch = Input.GetTouch(0); // Получаем первое касание

            PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
            pointerEventData.position = touch.position;

            // Создаем список для хранения результатов рейкаста
            var results = new System.Collections.Generic.List<RaycastResult>();

            // Выполняем рейкаст
            EventSystem.current.RaycastAll(pointerEventData, results);

            bool isTutorialCardHit = false;

            // Проверяем, попал ли рейкаст на карточку туториала
            foreach (var result in results)
            {
                if (result.gameObject == PopupWindow)
                {
                    isTutorialCardHit = true;
                    break;
                }
            }

            if (isTutorialCardHit)
            {
                // Если попал, то можно обработать нажатие на карточку
                Debug.Log("Нажата карточка туториала!");
            }
            else
            {
                // Если не попал, блокируем нажатие
                Debug.Log("Нажатие заблокировано!");
            }
        }
    }
        
    public void OnClosePopup()
    {
        PopupWindow.SetActive(false);
        PlayerPrefs.SetInt("HasShownTutorialMining", 1);
        PlayerPrefs.Save();
    }
}