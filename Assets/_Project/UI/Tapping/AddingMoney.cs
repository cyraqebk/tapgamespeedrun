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
            if (money != null)
            {
                money.Changed += OnMoneyChanged;
                moneyText.text = money.Value.ToString(); 
            }
        }

        private void OnDisable()
        {
            if (money != null)
            {
                money.Changed -= OnMoneyChanged;
            }
        }

        private void OnMoneyChanged(int oldValue, int newValue)
        {
            moneyText.text = newValue.ToString();
        }
    }
}
