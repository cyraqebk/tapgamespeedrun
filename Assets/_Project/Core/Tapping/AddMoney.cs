using UnityEngine;

using Core.ReactiveFields;

namespace Core.Tappings
{
    public class AddMoney : MonoBehaviour
    {
        [SerializeField] private ReactiveField<int> money;


        private void Awake()
        {
            money = new ReactiveField<int>(0);
            Debug.Log("Инициализация money с значением 0.");
        }

        public void AddMoneys(int amount)
        {
            Debug.Log($"Добавляем деньги: {amount}");
            money.Value += amount;
        }

        public ReactiveField<int> GetMoneyField()
        {
            return money;
        }
    }
}
