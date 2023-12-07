using System;
using Game.Database;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[RequireComponent(typeof(CircleCollider2D))]
public class Enemy : MonoBehaviour
{
   public float currentHp;

    private string monsterName;
    private int monsterId;
    private float movSpd;
    private float maxHp;
    private float hitBoxSize;
    private float monSkillStat1;
    private float monSkillStat2;
    private float monSkillStat3;
    private float coolTime;
    private float coolTimeLeft;
    MobSkillBase mobSkillData;
    
    private void Start()
    {
        currentHp = maxHp;
        GetComponent<CircleCollider2D>().radius = hitBoxSize;
        mobSkillData = MobSkillBase.LoadSkill(monsterId);
        mobSkillData.Init(new[] {monSkillStat1, monSkillStat2, monSkillStat3});
        coolTimeLeft = 0;
        
        GetComponentInChildren<Text>().text = monsterName;
    }

    void Update()
    {
        transform.position += Vector3.left * (movSpd * Time.deltaTime);
        coolTimeLeft -= Time.deltaTime;
        
        if (!coolTime.Equals(0) && coolTimeLeft <= 0)
        {
            mobSkillData.OnStart(this);
            coolTimeLeft = coolTime;
        }
        
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
        currentHp -= dmg;

        if (currentHp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Initialize(EnemyData data)
    {
        monsterName = data.monsterName;
        monsterId = data.monsterId;
        movSpd = data.movSpd;
        maxHp = data.maxHP;
        hitBoxSize = data.hitBoxSize;
        monSkillStat1 = data.monSkillStat1;
        monSkillStat2 = data.monSkillStat2;
        monSkillStat3 = data.monSkillStat3;
        coolTime = data.coolTime;
    }
}
