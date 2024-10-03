using UnityEngine;

public class Mine: MonoBehaviour
{
    public int totalMiningPower = 0;  // Общая мощность майнинга

    public void AddMiner(int power)
    {
        totalMiningPower += power;
        Debug.Log($"Добавлена мощность: {power}. Общая мощность: {totalMiningPower}");
    }
}