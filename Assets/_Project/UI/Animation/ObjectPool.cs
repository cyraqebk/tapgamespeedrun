using UnityEngine;
using System.Collections.Generic;

namespace UI.Animation
{
    public class ObjectPool : MonoBehaviour
    {
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform _tappingParrent;
    [SerializeField] private int poolSize = 10;
    private List<GameObject> pool = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab, _tappingParrent);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetObject()
    {
        foreach (var obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        // Если все объекты заняты, создаем новый
        GameObject newObj = Instantiate(prefab, _tappingParrent);
        pool.Add(newObj);
        return newObj;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
    }
    }
}
