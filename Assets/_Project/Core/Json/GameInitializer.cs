using UnityEngine;
using Core.Json;
using System;
using System.Collections;

public class GameInitializer : MonoBehaviour
{
    public event Action StopGame; // Событие для сохранения данных при завершении

    private void Awake()
    {
        // Загрузка данных при старте игры
        Memory.LoadFromFile();
        StartCoroutine(SaveGameEvery15Seconds());
        Memory.CreateTestFile();
    }

    public void SubscribeToStopGame(Action handler)
    {
        StopGame += handler;
    }

    public void UnsubscribeFromStopGame(Action handler)
    {
        StopGame -= handler;
    }

    // Срабатывает при сворачивании приложения или потере фокуса
    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            Debug.Log("Сохранение сработало", this);
            SaveGame();
        }
    }

    // Срабатывает, когда приложение теряет или восстанавливает фокус
    private void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            SaveGame();
        }
    }

    // Срабатывает при завершении приложения
    private void OnApplicationQuit()
    {
        SaveGame();
    }

    // Метод для вызова сохранения данных
    private void SaveGame()
    {
        StopGame?.Invoke(); // Вызов события сохранения данных у всех подписчиков
        Memory.SaveToFile(); // Централизованное сохранение в файл
    }
    private IEnumerator SaveGameEvery15Seconds()
    {
        while (true)
        {
            yield return new WaitForSeconds(15); // Ожидание 15 секунд
            SaveGame(); // Сохранение данных
        }
    }
}
