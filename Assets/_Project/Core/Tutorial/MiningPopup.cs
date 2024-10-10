using UnityEngine;

public class MiningPopup : MonoBehaviour
{
    public GameObject PopupWindow;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("HasShownTutorialMining"))
        {
            PopupWindow.SetActive(true);
        }
        else
        {
            PopupWindow.SetActive(false);
        }
    }
    public void OnClosePopup()
    {
        PopupWindow.SetActive(false);
        PlayerPrefs.SetInt("HasShownTutorialMining", 1);
        PlayerPrefs.Save();
    }
}