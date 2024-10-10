using UnityEngine;
using UnityEngine.Android;

namespace Core.Setting
{
    public class Android : MonoBehaviour
    {
        void Start()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
        {
            // Запрос разрешения на запись
            Permission.RequestUserPermission(Permission.ExternalStorageWrite);
        }

        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageRead))
        {
            // Запрос разрешения на чтение
            Permission.RequestUserPermission(Permission.ExternalStorageRead);
        }
    }
    }
}
