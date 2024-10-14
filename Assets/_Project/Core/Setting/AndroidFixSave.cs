using UnityEngine;
using UnityEngine.Android;

namespace Core.Setting
{
    public class AndroidFixSave : MonoBehaviour
    {
        void Start()
        {
            // Проверяем, есть ли разрешения на запись и чтение
            if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
            {
                Permission.RequestUserPermission(Permission.ExternalStorageWrite);
            }
            
            if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageRead))
            {
                Permission.RequestUserPermission(Permission.ExternalStorageRead);
            }

            // Проверяем разрешения после запроса
            CheckPermissions();
        }

        private void CheckPermissions()
        {
            if (Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite) &&
                Permission.HasUserAuthorizedPermission(Permission.ExternalStorageRead))
            {
                Debug.Log("[PermissionManager] Permissions granted.");
                // Здесь можно продолжить выполнение сохранения или загрузки данных
            }
            else
            {
                Debug.Log("[PermissionManager] Permissions not granted.");
            }
        }
    }
}
