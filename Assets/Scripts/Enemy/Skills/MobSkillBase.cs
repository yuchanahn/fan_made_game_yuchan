using System;
using UnityEngine;

public class MobSkillBase
{
    public virtual void Init(float[] data)
    {
        Debug.LogError("Init in base!");
    }

    public virtual void OnStart(Enemy enemy)
    {
        Debug.Log("MobSkillBase");
    }

    public static MobSkillBase LoadSkill(int mobId) => mobId switch
    {
        1001 => new MobDefaultSkillData(),
        1002 => new Mob1002SkillData(),
        _ => new MobDefaultSkillData()
    };
}