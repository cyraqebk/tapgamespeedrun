using UnityEngine;
using Core.Json;

public class GameInitializer : MonoBehaviour
{
    public delegate void SaveDelegate();
    public event SaveDelegate StopGame;
    private void Awake()
    {
        Memory.LoadFromFile();
    }
    private void OnApplicationQuit() 
    {
        StopGame?.Invoke();
    }
}
