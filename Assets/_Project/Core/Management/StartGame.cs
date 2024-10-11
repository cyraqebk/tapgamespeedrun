using UnityEngine;

namespace Core.Management
{
    public class StartGame : MonoBehaviour
    {
        [SerializeField] public Canvas Wallet;
        [SerializeField] public Canvas Tapping;
        [SerializeField] public Canvas Settings;
        [SerializeField] public Canvas Management;
        [SerializeField] public Canvas Mining;
        public CanvasGroup walletCanvasGroup;
        public CanvasGroup tappingCanvasGroup;
        public CanvasGroup settingsCanvasGroup;
        public CanvasGroup managementCanvasGroup;
        public CanvasGroup miningCanvasGroup;
        
        private void Awake()
        {
            walletCanvasGroup = Wallet.GetComponent<CanvasGroup>();
            tappingCanvasGroup = Tapping.GetComponent<CanvasGroup>();
            settingsCanvasGroup = Settings.GetComponent<CanvasGroup>();
            managementCanvasGroup = Management.GetComponent<CanvasGroup>();
            miningCanvasGroup = Mining.GetComponent<CanvasGroup>();
        }
        public void Start()
        {
            Off(walletCanvasGroup);
            On(tappingCanvasGroup);
            Off(settingsCanvasGroup);
            On(managementCanvasGroup);
            Off(miningCanvasGroup);
        }

        public void Off(CanvasGroup canvasGroup)
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }

        public void On(CanvasGroup canvasGroup)
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true; 
        }
    }
}
