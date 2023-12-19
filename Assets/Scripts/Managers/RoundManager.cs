using System;
using UnityEngine;

public class RoundManager : Singleton<RoundManager>
{
    public Action onRoundStart = null;
    public Action onRoundStartOnce;
    public Action onRoundEnd = null;
    public Action onRoundEndOnce;

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
        if (!isRoundStarted || FindAnyObjectByType<Enemy>()) return;
        
        isRoundStarted = false;
        OnRoundEnded();
    }
}
