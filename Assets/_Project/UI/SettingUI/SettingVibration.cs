using UnityEngine;
using UnityEngine.EventSystems;
using Core.Setting;
using TMPro;


namespace UI.Setting
{
    public class SettingVibration : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Settings settings;
        [SerializeField] private TMP_Text vibration;
        private void Start() 
        {
            vibration.text = "Да";
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            if (settings.vbr)
            {
                vibration.text = "Нет";
                settings.vbr = false;
            }
            else
            {
                vibration.text = "Да";
                settings.vbr = true;
            }
        }
    }
}
