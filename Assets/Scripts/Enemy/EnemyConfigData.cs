using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SJJ.GoogleSheetsDatabase;

namespace Game.Database
{
    [CreateAssetMenu(fileName = "EnemyConfigData", menuName = "ConfigData/EnemyConfigData")]
    public class EnemyConfigData : DataContainerBase
    {
        [PageName("monsterStat")]
        public List<EnemyData> monsterStat;
    }

    [System.Serializable]
    public class EnemyData
    {
        public string monsterName;
        public int monsterId;
        public float movSpd;
        public float maxHP;
        public float hitBoxSize;
        public float monSkillStat1;
        public float monSkillStat2;
        public float monSkillStat3;
        public float coolTime;
    }
}