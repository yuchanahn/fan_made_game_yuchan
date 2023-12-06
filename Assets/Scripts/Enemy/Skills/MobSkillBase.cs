using System;
using UnityEngine;

public class MobSkillBase
{
    public virtual void OnStart(Enemy enemy)
    {
        Debug.Log("MobSkillBase");
    }

    public static MobSkillBase LoadSkill(int mobId) => mobId switch
    {
        1001 => new Mob1001SkillData(),
        1002 => new Mob1001SkillData(),
        _ => null
    };
}