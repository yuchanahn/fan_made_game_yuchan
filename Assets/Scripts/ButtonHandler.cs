using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    #region Public Variables
    [Tooltip("배치할 프리팹")]
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

        if (objectPrefabs.Length == 0)
        {
            Debug.LogError("배치할 프리팹이 설정되지 않았습니다.");
            return;
        }

        int randomIndex = Random.Range(0, objectPrefabs.Length);
        GameObject selectedPrefab = objectPrefabs[randomIndex];

        slotGenerator.PlacePrefabInRandomSlot(selectedPrefab);
    }
}
