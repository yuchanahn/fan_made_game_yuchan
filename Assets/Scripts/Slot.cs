using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private bool isPrefabPlaced = false; // �������� ��ġ�Ǿ����� ����

    public bool PlacePrefab(GameObject prefab)
    {
        if (isPrefabPlaced)
        {
            // �̹� �������� ��ġ�� ���
            return false;
        }

        Instantiate(prefab, transform.position, Quaternion.identity);
        isPrefabPlaced = true; // ������ ��ġ ���� ������Ʈ
        return true;
    }

    // ������ ��ġ ���θ� Ȯ��.
    public bool IsPrefabPlaced()
    {
        return isPrefabPlaced;
    }
}
