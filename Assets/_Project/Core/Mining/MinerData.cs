using UnityEngine;

namespace Core.Mining
{
    [CreateAssetMenu(fileName = "NewMinerData", menuName = "Miners/MinerData")]
    public class MinerData : ScriptableObject
        {
            public string minerName;   
            public int initialCost;    // Начальная стоимость майнера
            public int upgradeCost;    // Стоимость апгрейда
            public int initialPower;   // Мощность майнера (сколько ресурсов приносит)
        }
    }
