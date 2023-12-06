using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public List<GameObject> spawnTransform = new List<GameObject>();
    private RoundSettings roundSettings;
    public List<int> selectedSpawnPointIndices;

    private void Awake()
    {
        roundSettings = GetComponent<RoundSettings>();
        GameManager.Instance.OnRoundStart += SpawnMonster;
    }

    private void Start()
    {
        selectedSpawnPointIndices = new List<int>();
        UpdateSpawnPoints();
    }

    // 소환 위치 업데이트 메서드
    public void UpdateSpawnPoints()
    {
        selectedSpawnPointIndices.Clear();
        HashSet<int> uniqueIndices = new HashSet<int>();
        int spawnLaneNum = roundSettings.spawnLaneNum;

        while (uniqueIndices.Count < spawnLaneNum)
        {
            uniqueIndices.Add(Random.Range(0, spawnTransform.Count));
        }

        selectedSpawnPointIndices.AddRange(uniqueIndices);
    }

    public void SpawnMonster()
    {
        int[] monsterIds = roundSettings.monsterId;
        int[] spawnNums = roundSettings.spawnNum;

        for (int i = 0; i < monsterIds.Length; i++)
        {
            int monsterId = monsterIds[i];
            int numToSpawn = spawnNums[i];

            for (int j = 0; j < numToSpawn; j++)
            {
                int spawnPointIndex = Random.Range(0, selectedSpawnPointIndices.Count);
                Transform spawnPoint = spawnTransform[selectedSpawnPointIndices[spawnPointIndex]].transform;

                GameObject monsterPrefab = ResourcesManager.Instance.GetPrefabById(monsterId);
                if (monsterPrefab != null)
                {
                    Instantiate(monsterPrefab, spawnPoint.position, spawnPoint.rotation);
                }
                else
                {
                    Debug.LogError("Monster prefab not found for id: " + monsterId);
                }
            }
        }

        GameManager.Instance.currentRound++;
        UpdateSpawnPoints();
    }
}
