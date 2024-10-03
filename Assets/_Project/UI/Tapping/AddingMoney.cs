using UnityEngine;
using TMPro;
using Core.ReactiveFields;
using Core.Tappings;

namespace UI.Tappings
{
    public class AddingMoney : MonoBehaviour
    {
        [SerializeField] private TMP_Text moneyText;
        private ReactiveField<int> money;
        [SerializeField] private AddMoney addMoney;

        private void Awake()
        {
            money = addMoney.GetMoneyField();
        }

        private void OnEnable()
        {
            Debug.Log("Подписались");
            money.Changed += OnMoneyChanged;
            moneyText.text = money.Value.ToString(); 

        }

        private void OnDisable()
        {

            money.Changed -= OnMoneyChanged;
        }

        private void OnMoneyChanged(int oldValue, int newValue)
        {

            Debug.Log("Пишем");

        }
    }
}
