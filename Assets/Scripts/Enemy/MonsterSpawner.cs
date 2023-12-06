using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public List<GameObject> spawnTransform = new List<GameObject>();

    private RoundSettings roundSettings;

    private void Awake()
    {
        GameManager.Instance.OnRoundStart += SpawnMonster;
    }

    private void Start()
    {
        roundSettings = GetComponent<RoundSettings>();
    }

    public void SpawnMonster()
    {
        Debug.Log("SpawnMonster");

        int[] monsterIds = roundSettings.monsterId;
        int[] spawnNums = roundSettings.spawnNum;
        int spawnLaneNum = roundSettings.spawnLaneNum; // spawnLaneNum Ãß°¡

        HashSet<int> selectedSpawnPoints = new HashSet<int>();

        while (selectedSpawnPoints.Count < spawnLaneNum)
        {
            selectedSpawnPoints.Add(Random.Range(0, spawnTransform.Count));
        }

        for (int i = 0; i < monsterIds.Length; i++)
        {
            int monsterId = monsterIds[i];
            int numToSpawn = spawnNums[i];

            for (int j = 0; j < numToSpawn; j++)
            {
                int randomIndex = Random.Range(0, selectedSpawnPoints.Count);
                int spawnPointIndex = new List<int>(selectedSpawnPoints)[randomIndex];
                Transform spawnPoint = spawnTransform[spawnPointIndex].transform;

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
    }

}
