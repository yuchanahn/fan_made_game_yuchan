using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Lane : MonoBehaviour
{
    public int currentLane;

    [Tooltip("현재 라인에 존재하는 몬스터 수")]
    public int enemyCount;

    public SpriteRenderer waveIndicator;
    
    private void Start()
    {
        GameManager.Instance.lanes.Add(this);
    }

    private void Awake()
    {
        waveIndicator = GetComponentsInChildren<SpriteRenderer>().First(x => x.gameObject.name == "WaveIndicator");
    }

    void Update()
    {
        Enemy[] enemies = GetComponentsInChildren<Enemy>();
        enemyCount = enemies.Length;
    }

    public void SetLaneReddy(bool isReddy)
    {
        var color = waveIndicator.color;
        color.a = isReddy ? 0.5f : 0.0f;
        waveIndicator.color = color;
    }
}
