using UnityEngine;

public class Mob1001SkillData : MobSkillBase
{
    float moveLane;

    public override void Init(float[] data)
    {
        moveLane = data[0];   
        Debug.Log($"data : {data[0]},{data[1]},{data[2]}");
    }

    public override void OnStart(Enemy enemy)
    {
        Debug.Log("Mob1001Skill!!");
    }
}