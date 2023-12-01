using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    #region Public Variables
    [Tooltip("��ġ�� ������")]
    public GameObject[] objectPrefabs;
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

        if (objectPrefabs.Length == 0)
        {
            Debug.LogError("��ġ�� �������� �������� �ʾҽ��ϴ�.");
            return;
        }

        int randomIndex = Random.Range(0, objectPrefabs.Length);
        GameObject selectedPrefab = objectPrefabs[randomIndex];

        slotGenerator.PlacePrefabInRandomSlot(selectedPrefab);
    }
}
