using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobDefaultSkillData : MobSkillBase
{
    public override void Init(float[] data)
    {
        Debug.Log($"default skill data : {data[0]},{data[1]},{data[2]}");
    }

    public override void OnStart(Enemy enemy)
    {
        Debug.LogError("default skill used");
    }
}
