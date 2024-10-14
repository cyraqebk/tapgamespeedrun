using UnityEngine;
using UnityEngine.UI;

namespace Core.Management
{
    public class StartGame : MonoBehaviour
    {
        // Убедитесь, что эти поля имеют уровень доступа public
        public CanvasGroup walletCanvasGroup;
        public CanvasGroup tappingCanvasGroup;
        public CanvasGroup settingsCanvasGroup;
        public CanvasGroup managementCanvasGroup;
        public CanvasGroup miningCanvasGroup;

        // Поля для изображений кнопок
        public Image walletButtonImage; // Изображение кнопки для кошелька
        public Image miningButtonImage; // Изображение кнопки для майнинга
        public Image tappingButtonImage; // Изображение кнопки для таппинга

        public void Off(CanvasGroup canvasGroup, Image buttonImage)
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;

            if (buttonImage != null)
            {
                Color newColor;
                if (ColorUtility.TryParseHtmlString("#7D3333", out newColor))
                {
                    buttonImage.color = newColor; // Изменяем цвет кнопки на #7D3333
                }
            }
        }

        public void On(CanvasGroup canvasGroup, Image buttonImage)
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;

            if (buttonImage != null)
            {
                buttonImage.color = Color.yellow; // Измените на желаемый цвет для активной кнопки
            }
        }

        public void Start()
        {
            Off(walletCanvasGroup, walletButtonImage);
            On(tappingCanvasGroup, tappingButtonImage);
            Off(settingsCanvasGroup, null);
            On(managementCanvasGroup, null);
            Off(miningCanvasGroup, miningButtonImage);
        }
    }
}
