using System;
using UnityEngine;
using UnityEngine.Serialization;

public class RoundManager : Singleton<RoundManager>
{
    public Action onRoundStart = null;
    public Action onRoundStartOnce;
    public Action onRoundEnd = null;
    public Action onRoundEndOnce;
    
    public int CurrentMonsterCount => FindObjectsOfType<Enemy>().Length;
    public int maxMonstersInRound;
    public int spawnedMonsters;

    private bool IsAllMonsterSpawned => spawnedMonsters >= maxMonstersInRound;

    [SerializeField] private bool isRoundStarted = true;
    public void OnRoundStarted()
    {
        onRoundStart?.Invoke();
        onRoundStartOnce?.Invoke();
        onRoundStartOnce = null;
        
        isRoundStarted = true;
        
        Debug.Log("Round Started");
    }
    
    public void OnRoundEnded()
    {
        onRoundEnd?.Invoke();
        onRoundEndOnce?.Invoke();
        onRoundEndOnce = null;
        
        isRoundStarted = false;
        GameManager.Instance.isGameStart = false;

        Debug.Log("Round Ended");
    }

    private void Update()
    {
        if (!isRoundStarted || FindAnyObjectByType<Enemy>() || !IsAllMonsterSpawned) return;
        
        spawnedMonsters = 0;
        isRoundStarted = false;
        OnRoundEnded();
    }
}
