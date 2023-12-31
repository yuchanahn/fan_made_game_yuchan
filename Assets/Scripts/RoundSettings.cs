using Game.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSettings : MonoBehaviour
{
    public int round;
    public int[] monsterId;
    public int[] spawnNum;
    public int spawnLaneNum;
    public int boss;
    public int bossLane;

    public void Initialize(RoundData data, int[] monid, int[] spawnnum)
    {
        round = data.round;
        monsterId = monid;
        spawnNum = spawnnum;
        spawnLaneNum = data.spawnLaneNum;
        boss = data.boss;
        bossLane = data.bossLane;
    }
}
