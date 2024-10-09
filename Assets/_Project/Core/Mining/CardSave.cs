// using UnityEngine;
// using System.IO;

// namespace Core.Mining
// {
//     public class CardSave : MonoBehaviour
//     {
//         public string filePath;
//         private CardData cardData;

//         private void Start()
//         {
//             filePath = Path.Combine(Application.persistentDataPath, "card1.json");
//             LoadCard();
//         }

//         public void SaveCard(CardData cardData)
//         {
//             string json = JsonUtility.ToJson(cardData);
//             File.WriteAllText(filePath, json);
//             Debug.Log("Card saved to " + filePath);
//         }
//         public CardData LoadCard()
//         {
//             if (File.Exists(filePath))
//             {
//                 string json = File.ReadAllText(filePath);
//                 CardData cardData = JsonUtility.FromJson<CardData>(json);
//                 Debug.Log("Card loaded from " + filePath);
//                 return cardData;
//             }
//             else
//             {
//                 Debug.LogWarning("No save file found at " + filePath);
//                 return null; // Или создайте новую карточку по умолчанию
//             }
//         }
//         private void OnApplicationQuit()
//         {
//             Debug.Log("SOHRANILOS");
//            SaveCard(cardData); // Сохраняем данные при выходе из приложения
//         }
//         private void OnApplicationPause()
//         {
//             Debug.Log("SOHRANILOS");
//            SaveCard(cardData); // Сохраняем данные при выходе из приложения
//         }
//     }
// }
