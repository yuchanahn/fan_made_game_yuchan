﻿using UnityEngine;

public class Mob1001SkillData : MobSkillBase
{
    public override void Init(float[] data)
    {
        Debug.Log($"data : {data[0]},{data[1]},{data[2]}");
    }

    public override void OnStart(Enemy enemy)
    {
        Debug.Log("Mob1001Skill!!");
    }
}