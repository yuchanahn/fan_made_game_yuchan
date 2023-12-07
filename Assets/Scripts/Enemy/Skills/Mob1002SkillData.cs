using UnityEngine;

public class Mob1002SkillData : MobSkillBase
{
    float moveLane;

    public override void Init(float[] data)
    {
        moveLane = data[0];   
        Debug.Log($"data : {data[0]},{data[1]},{data[2]}");
    }

    public override void OnStart(Enemy enemy)
    {
        var moveDelta = (int)moveLane * Random.Range(0, 2) * 2 - 1;
        var targetLane = enemy.currentLane + moveDelta;
        if(targetLane < 0 || GameManager.Instance.lanes.Count <= targetLane)
            targetLane = enemy.currentLane - moveDelta * 2;
        targetLane = Mathf.Clamp(targetLane, 0, GameManager.Instance.lanes.Count - 1);
        enemy.currentLane = targetLane;
    }
}