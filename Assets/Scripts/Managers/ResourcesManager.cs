using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : Singleton<ResourcesManager>
{
    public GameObject GetPrefabById(int id)
    {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/" + id.ToString());
        if (prefab != null)
        {
            return prefab;
        }
        else
        {
            Debug.Log("Prefab not found for id: " + id.ToString());
            return null;
        }
    }
}
