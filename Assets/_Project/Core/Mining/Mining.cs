using System.Collections;
using UnityEngine;
using TMPro;


namespace Core.Mining
{
    public class Mining : MonoBehaviour
    {
       [SerializeField] int money;
       public TMP_Text moneyText;
        void Start()
        {
            // тут должна быть общая переменная монет
            // возвращаем деньги которые были до этого
            money = PlayerPrefs.GetInt("money");
            // точка входа в нумератор
            StartCoroutine(MiningLow());




            IEnumerator MiningLow()
            {
                // метод для счета 1 сек
                yield return new WaitForSeconds(1);
                money++;
                Debug.Log(money);
                // сохраняем деньги в мани
                PlayerPrefs.SetInt("money",money);
                // запуск счета
                StartCoroutine(MiningLow());
            }    
        }
    }
}
