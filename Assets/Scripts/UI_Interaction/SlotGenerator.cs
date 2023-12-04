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

    private void Awake()
    {
        GameManager.Instance.slotGenerator = this;
    }

    private void Start()
    {
        if (!ValidatePrefab())
        {
            return;
        }

        GenerateSlots();
    }

    private bool ValidatePrefab()
    {
        if (slotPrefab == null)
        {
            Debug.LogError("���� �������� �������� �ʾҽ��ϴ�.");
            return false;
        }
        return true;
    }

    private void GenerateSlots()
    {
        Vector3 parentPosition = this.transform.position;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                CreateSlot(x, y, parentPosition);
            }
        }
    }

    private void CreateSlot(int x, int y, Vector3 parentPosition)
    {
        Vector3 position = CalculateSlotPosition(x, y, parentPosition);
        GameObject newSlotObject = Instantiate(slotPrefab, position, Quaternion.identity);
        newSlotObject.transform.parent = this.transform;

        Slot slotComponent = newSlotObject.GetComponent<Slot>();
        if (slotComponent == null)
        {
            Debug.LogWarning("������ ���Կ� Slot ������Ʈ�� �����ϴ�: " + newSlotObject.name);
            return;
        }

        slots.Add(slotComponent);
    }

    private Vector3 CalculateSlotPosition(int x, int y, Vector3 parentPosition)
    {
        return new Vector3(x * slotSpacingX, y * slotSpacingY, 0) + parentPosition;
    }

    public void PlacePrefabInRandomSlot(GameObject prefab)
    {
        if (prefab == null)
        {
            Debug.LogError("��ġ�� �������� �������� �ʾҽ��ϴ�.");
            return;
        }

        if (slots.Count == 0)
        {
            Debug.LogError("������ �������� �ʾҽ��ϴ�.");
            return;
        }

        int attempts = 0; // ��ġ �õ� Ƚ��
        bool placed = false;

        while (!placed && attempts < slots.Count)
        {
            int randomIndex = Random.Range(0, slots.Count);
            Slot randomSlot = slots[randomIndex];

            placed = randomSlot.PlacePrefab(prefab);
            attempts++;
        }

        if (!placed)
        {
            Debug.Log("��� ������ �̹� ���ֽ��ϴ�.");
        }
    }
}
