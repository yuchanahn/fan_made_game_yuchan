using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    public int currentLane;

    [Tooltip("���� ���ο� �����ϴ� ���� ��")]
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
