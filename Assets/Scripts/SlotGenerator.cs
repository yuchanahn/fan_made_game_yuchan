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
        GenerateSlots();
    }

    private void GenerateSlots()
    {
        if (slotPrefab == null)
        {
            Debug.LogError("슬롯 프리팹이 설정되지 않았습니다.");
            return;
        }

        Vector3 parentPosition = this.transform.position; // 부모 오브젝트의 위치

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // 슬롯의 실제 위치 계산 (부모 오브젝트 위치 포함)
                Vector3 position = new Vector3(x * slotSpacingX, y * slotSpacingY, 0) + parentPosition;

                // 슬롯 인스턴스 생성
                GameObject newSlot = Instantiate(slotPrefab, position, Quaternion.identity);
                newSlot.transform.parent = this.transform; // 생성된 슬롯을 현재 객체의 자식으로 설정

                // 슬롯 컴포넌트 가져오기
                Slot slot = newSlot.GetComponent<Slot>();

                if (slot == null)
                {
                    Debug.LogError("슬롯 컴포넌트가 없습니다.");
                    return;
                }

                slots.Add(slot);
            }
        }
    }
}