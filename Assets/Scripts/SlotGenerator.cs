using System.Collections.Generic;
using UnityEngine;

public class SlotGenerator : MonoBehaviour
{
    #region Public Variables
    [Tooltip("���� ������")]
    public GameObject slotPrefab;

    [Tooltip("���� ĭ ��")]
    public int width = 5;

    [Tooltip("���� ĭ ��")]
    public int height = 10;

    [Tooltip("���� ���� ���� ���� ����")]
    public float slotSpacingX = 1.0f;

    [Tooltip("���� ���� ���� ���� ����")]
    public float slotSpacingY = 1.0f;
    #endregion

    #region Private Variables
    private List<Slot> slots = new List<Slot>();
    #endregion

    private void Start()
    {
        GenerateSlots();
    }

    private void GenerateSlots()
    {
        if (slotPrefab == null)
        {
            Debug.LogError("���� �������� �������� �ʾҽ��ϴ�.");
            return;
        }

        Vector3 parentPosition = this.transform.position; // �θ� ������Ʈ�� ��ġ

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // ������ ���� ��ġ ��� (�θ� ������Ʈ ��ġ ����)
                Vector3 position = new Vector3(x * slotSpacingX, y * slotSpacingY, 0) + parentPosition;

                // ���� �ν��Ͻ� ����
                GameObject newSlot = Instantiate(slotPrefab, position, Quaternion.identity);
                newSlot.transform.parent = this.transform; // ������ ������ ���� ��ü�� �ڽ����� ����

                // ���� ������Ʈ ��������
                Slot slot = newSlot.GetComponent<Slot>();

                if (slot == null)
                {
                    Debug.LogError("���� ������Ʈ�� �����ϴ�.");
                    return;
                }

                slots.Add(slot);
            }
        }
    }
}