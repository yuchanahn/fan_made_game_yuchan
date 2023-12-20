using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public List<GameObject> spawnTransform = new();
    private RoundSettings roundSettings;
    public List<int> selectedSpawnPointIndices;
    
    public List<Queue<GameObject>> spawnTargets = new();
    public float spawnInterval = 1.0f;
    
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

        if (spawnTransform.Count > 0)
        {
            RoundManager.Instance.onRoundEndOnce += () =>
                selectedSpawnPointIndices.ForEach(x => spawnTransform[x].GetComponent<Lane>().SetLaneReddy(true));
        }
    }

    public void SpawnMonster()
    {
        selectedSpawnPointIndices.ForEach(x => spawnTransform[x].GetComponent<Lane>().SetLaneReddy(false));
        RoundManager.Instance.OnRoundStarted();
        
        int[] monsterIds = roundSettings.monsterId;
        int[] spawnNums = roundSettings.spawnNum;
        RoundManager.Instance.maxMonstersInRound = spawnNums.Sum();
        RoundManager.Instance.spawnedMonsters = 0;

        for (int i = 0; i < monsterIds.Length; i++)
        {
            int monsterId = monsterIds[i];
            int numToSpawn = spawnNums[i];

            for (int j = 0; j < numToSpawn; j++)
            {
                int spawnPointIndex = Random.Range(0, selectedSpawnPointIndices.Count);
                var pointIndex = selectedSpawnPointIndices[spawnPointIndex];
                Transform spawnPoint = spawnTransform[pointIndex].transform;

                GameObject monsterPrefab = ResourcesManager.Instance.GetPrefabById(monsterId);
                
                if (monsterPrefab != null)
                {
                    spawnTargets[pointIndex].Enqueue(monsterPrefab);
                    //Instantiate(monsterPrefab, spawnPoint.position, spawnPoint.rotation, spawnPoint);
                }
                else
                {
                    Debug.LogError("Monster prefab not found for id: " + monsterId);
                }
            }
        }
        StartCoroutine(RealSpawnMonster());
        GameManager.Instance.currentRound++;
        UpdateSpawnPoints();
    }

    IEnumerator RealSpawnMonster()
    {
        while(spawnTargets.Any(x => x.Any())) {
            for (var i = 0; i < spawnTargets.Count; i++)
            {
                if (!spawnTargets[i].Any()) continue;

                var spawnPoint = spawnTransform[i].transform;
                var monsterPrefab = spawnTargets[i].Dequeue();
                var enemy = Instantiate(monsterPrefab, spawnPoint.position, spawnPoint.rotation, spawnPoint);
                enemy.GetComponent<Enemy>().currentLane = i;
                RoundManager.Instance.spawnedMonsters++;
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
