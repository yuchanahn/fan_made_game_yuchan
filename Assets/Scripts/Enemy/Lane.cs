using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    public int currentLane;

    [Tooltip("현재 라인에 존재하는 몬스터 수")]
    public int enemyCount;

    private void Start()
    {
        GameManager.Instance.lanes.Add(this);
    }

    void Update()
    {
        Enemy[] enemies = GetComponentsInChildren<Enemy>();
        enemyCount = enemies.Length;
    }
}
