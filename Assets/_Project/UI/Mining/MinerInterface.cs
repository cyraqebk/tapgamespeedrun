using UnityEngine;
using UnityEngine.UI;
using Core.Mining;

namespace UI.Mining
{
    
    public class MinerCard : MonoBehaviour
    {
        public MinerData minerData;  // Данные майнера через ScriptableObject
        public Text cardText;        // Текст для отображения данных майнера
        private void Start()
        {
            UpdateCardText();  // Обновляем текст карточки при старте
        }

        public void UpdateCardText()
        {
        cardText.text = $"{minerData.minerName}\nСтоимость: {minerData.initialCost}\nМощность: {minerData.initialPower}\nАпгрейд: {minerData.upgradeCost}";
        }
    }   
}