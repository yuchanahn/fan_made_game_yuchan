using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    #region Public Variables
    [Tooltip("��ũ���ͺ� ������Ʈ�κ��� ������ ������ ������")]
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
            Debug.LogError("Button ������Ʈ�� �� ���� ������Ʈ�� �����ϴ�.");
            return;
        }

        button.onClick.AddListener(OnButtonPressed);
    }

    public void OnButtonPressed()
    {
        if (slotGenerator == null)
        {
            Debug.LogError("SlotGenerator�� �������� �ʾҽ��ϴ�.");
            return;
        }

        GameObject selectedPrefab = prefabData.GetRandomPrefab();
        if (selectedPrefab == null)
        {
            return; // ���� �޽����� GetRandomPrefab �޼��忡�� ��µ˴ϴ�.
        }

        slotGenerator.PlacePrefabInRandomSlot(selectedPrefab);
    }
}
