using Game.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(CircleCollider2D))]
public class Enemy : MonoBehaviour
{
    public float currentHP;

    private string monsterName;
    private int monsterId;
    private float movSpd;
    private float maxHP;
    private float hitBoxSize;
    private float monSkillStat1;
    private float monSkillStat2;
    private float monSkillStat3;
    private float coolTime;

    private void Start()
    {
        currentHP = maxHP;
    }

    void Update()
    {
        transform.position += Vector3.left * (movSpd * Time.deltaTime);

        if (!(transform.position.x <= -5)) return;
        
        ApplyDamageOnArrival();
        Destroy(gameObject);
    }

    void ApplyDamageOnArrival()
    {
        Debug.Log("ApplyDamageOnArrival");
    }

    public void Damaged(float dmg)
    {
        currentHP -= dmg;

        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Initialize(EnemyData data)
    {
        monsterName = data.monsterName;
        monsterId = data.monsterId;
        movSpd = data.movSpd;
        maxHP = data.maxHP;
        hitBoxSize = data.hitBoxSize;
        monSkillStat1 = data.monSkillStat1;
        monSkillStat2 = data.monSkillStat2;
        monSkillStat3 = data.monSkillStat3;
        coolTime = data.coolTime;
    }
}
