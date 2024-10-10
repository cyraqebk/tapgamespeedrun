using UnityEngine;

public class WalletPopup : MonoBehaviour
{
    public GameObject PopupWindow;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("HasShownTutorialWallet"))
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
        PlayerPrefs.SetInt("HasShownTutorialWallet", 1);
        PlayerPrefs.Save();
    }
}
