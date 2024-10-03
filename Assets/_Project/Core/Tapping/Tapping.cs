using UnityEngine;

namespace Core.Tappings
{
    public class Tapping : MonoBehaviour
    {
        [SerializeField] private AddMoney addMoney;
        [field: SerializeField] private int ButtonValue;
        public void Tap()
        {
            Debug.Log("Перенёс");
        }
    }
}
