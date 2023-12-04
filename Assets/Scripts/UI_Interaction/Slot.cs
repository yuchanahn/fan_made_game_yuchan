using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private bool isPrefabPlaced = false; // 프리팹이 배치되었는지 여부

    public bool PlacePrefab(GameObject prefab)
    {
        if (isPrefabPlaced)
        {
            // 이미 프리팹이 배치된 경우
            return false;
        }

        Instantiate(prefab, transform.position, Quaternion.identity);
        isPrefabPlaced = true; // 프리팹 배치 상태 업데이트
        return true;
    }

    // 프리팹 배치 여부를 확인.
    public bool IsPrefabPlaced()
    {
        return isPrefabPlaced;
    }
}
