using UnityEngine;

namespace Core.Mining
{
    [CreateAssetMenu(fileName = "CardConfig", menuName = "Scriptable Objects/CardConfig")]
    public class CardConfig : ScriptableObject
    {
        public AnimationCurve PricePerLevel; //
        public AnimationCurve ProfitPerLevel; //
    }
}
