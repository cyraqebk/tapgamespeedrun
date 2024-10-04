using UnityEngine;

namespace Core.Tappings
{
    public class LevelUpgrade : MonoBehaviour
    {
        public AnimationCurve priiceCurve;
        public int MaxLevel = 10;
        private int _currenLevel = 1;
        public int GetUpgradeCost(int Level)
        {
            float normalizedLevel = (float)Level / (float)MaxLevel;
            float price = priiceCurve.Evaluate(normalizedLevel) * 1000;
            return Mathf.CeilToInt(price);
        }
        public void UpgradeLevel()
        {
            if (_currenLevel < MaxLevel)
            {
                int UpgradeCost = GetUpgradeCost(_currenLevel);
                Debug.Log("Стоимость апгрейда уровня " + _currenLevel + ": " + UpgradeCost + " Монет");
                _currenLevel++;
            }
            else
            {
                Debug.Log("Максимальный уровень достигнут!!!");
            }
        }
    }
}
