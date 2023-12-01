using System.Collections.Generic;
using UnityEngine;

public class SlotGenerator : MonoBehaviour
{
    #region Public Variables
    [Tooltip("슬롯 프리팹")]
    public GameObject slotPrefab;

    [Tooltip("가로 칸 수")]
    public int width = 5;

    [Tooltip("세로 칸 수")]
    public int height = 10;

    [Tooltip("가로 방향 슬롯 간의 간격")]
    public float slotSpacingX = 1.0f;

    [Tooltip("세로 방향 슬롯 간의 간격")]
    public float slotSpacingY = 1.0f;
    #endregion

    #region Private Variables
    private List<Slot> slots = new List<Slot>();
    #endregion

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
            Debug.LogError("슬롯 프리팹이 설정되지 않았습니다.");
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
            Debug.LogWarning("생성된 슬롯에 Slot 컴포넌트가 없습니다: " + newSlotObject.name);
            return;
        }

        slots.Add(slotComponent);
    }

    private Vector3 CalculateSlotPosition(int x, int y, Vector3 parentPosition)
    {
        return new Vector3(x * slotSpacingX, y * slotSpacingY, 0) + parentPosition;
    }
}
