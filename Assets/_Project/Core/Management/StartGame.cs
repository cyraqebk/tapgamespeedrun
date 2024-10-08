using UnityEngine;

namespace Core.Management
{
    public class StartGame : MonoBehaviour
    {
        [SerializeField] public Canvas Wallet;
        [SerializeField] public Canvas Tapping;
        [SerializeField] public Canvas Settings;
        [SerializeField] public Canvas Management;
        void Start()
        {
            Wallet.gameObject.SetActive(false);
            Tapping.gameObject.SetActive(true);
            Settings.gameObject.SetActive(false);
            Management.gameObject.SetActive(true);

        }
    }
}
