using UnityEngine;

namespace Core.Mining
{
    public class BuyMiner : MonoBehaviour
    {
        public int minerCost = 10;
        public int money;
        public void Buy()
    {
        if (money >= minerCost)  // Если ресурсов больше или равно стоимости майнера
        {
            money -= minerCost;  // Уменьшаем ресурсы на стоимость майнера
            AddMiner();  // Добавляем майнера
        }
        else
        {
            Debug.Log("Недостаточно ресурсов!");  // Выводим сообщение
        }
    }

        public void AddMiner()
        {

        }
    }
}
