using UnityEngine;
using UnityEngine.EventSystems;
using Core.Setting;
using TMPro;


namespace UI.Setting
{
    public class SettingValue : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Settings settings;
        [SerializeField] private TMP_Text value;
        private void Start() 
        {
            value.text = "Да";
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            if (value.text == "Да")
            {
                settings.MuteSound();
                value.text = "Нет";
            }
            else
            {
                settings.UnmuteSound();
                value.text = "Да";
            }
        }

    }
}
