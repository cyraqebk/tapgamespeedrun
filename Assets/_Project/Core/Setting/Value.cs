using UnityEngine;

namespace Core.Setting
{
    public class Value : MonoBehaviour
    {
        [SerializeField] private LocalisationWithArgument localisationComponent;

        private void Update()
        {
            // Обновляем значение вибрации
            localisationComponent.UpdateArgument("включена");
        }
    }
}
