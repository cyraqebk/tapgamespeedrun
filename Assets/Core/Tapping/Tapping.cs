using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Core.Tappings
{
    public class Tapping : MonoBehaviour
    {
        [SerializeField] int money;
        public TMP_Text moneyText;
        public void ButtonClick()
        {
            money++;
        }

        // Update is called once per frame
        void Update()
        {
            moneyText.text = money.ToString();
        }
    }
}
