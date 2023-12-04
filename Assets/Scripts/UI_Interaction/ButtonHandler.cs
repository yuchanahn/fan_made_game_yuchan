using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    #region Public Variables
    [Tooltip("스크립터블 오브젝트로부터 가져올 프리팹 데이터")]
    public PrefabData prefabData;
    #endregion

    #region Private Variables
    private SlotGenerator slotGenerator;
    private Button button;
    #endregion

    private void Start()
    {
        slotGenerator = GameManager.Instance.slotGenerator;

        button = GetComponent<Button>();
        if (button == null)
        {
            Debug.LogError("Button 컴포넌트가 이 게임 오브젝트에 없습니다.");
            return;
        }

        button.onClick.AddListener(OnButtonPressed);
    }

    public void OnButtonPressed()
    {
        if (slotGenerator == null)
        {
            Debug.LogError("SlotGenerator가 설정되지 않았습니다.");
            return;
        }

        GameObject selectedPrefab = prefabData.GetRandomPrefab();
        if (selectedPrefab == null)
        {
            return; // 에러 메시지는 GetRandomPrefab 메서드에서 출력됩니다.
        }

        slotGenerator.PlacePrefabInRandomSlot(selectedPrefab);
    }
}
