using UnityEngine;
using Core.Json;
using System;

public class GameInitializer : MonoBehaviour
{
    public delegate void SaveDelegate();
    public event SaveDelegate StopGame;
    public event Action OnSaveComplete;
    private void Awake()
    {
        Memory.LoadFromFile();
    }
    private void OnApplicationQuit()
    {
        StopGame?.Invoke();
        OnSaveComplete?.Invoke();
    }
}
