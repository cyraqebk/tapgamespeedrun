using UnityEngine;

public class OneTimePopup : MonoBehaviour
{
    public GameObject PopupWindow;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("HasShownTutorial"))
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
        PlayerPrefs.SetInt("HasShownTutorial", 1);
        PlayerPrefs.Save();
    }
}