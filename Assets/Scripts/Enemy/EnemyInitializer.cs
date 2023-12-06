using Game.Database;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyInitializer : MonoBehaviour
{
    [SerializeField] private EnemyConfigData enemyConfigData;

    [SerializeField] private int enemyId;

    private Enemy enemy;

    private void Awake()
    {
        if (enemy == null)
            enemy = GetComponent<Enemy>();

        InitializeEnemy();
    }

    public void InitializeEnemy()
    {
        var data = enemyConfigData.monsterStat.First(d => d.monsterId == enemyId);

        enemy.Initialize(data);
    }
}
