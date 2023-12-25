using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public bool isPrefabPlaced = false; // �������� ��ġ�Ǿ����� ����

    private void Update()
    {
        isPrefabPlaced = GetComponentInChildren<Unit>() != null;
    }

    public bool PlacePrefab(GameObject prefab)
    {
        if (isPrefabPlaced)
        {
            // �̹� �������� ��ġ�� ���
            return false;
        }

        GameObject placedPrefab = Instantiate(prefab, transform.position, Quaternion.identity);
        placedPrefab.transform.parent = this.transform;
        isPrefabPlaced = true; // ������ ��ġ ���� ������Ʈ
        return true;
    }

    // ������ ��ġ ���θ� Ȯ��.
    public bool IsPrefabPlaced()
    {
        return isPrefabPlaced;
    }
}
