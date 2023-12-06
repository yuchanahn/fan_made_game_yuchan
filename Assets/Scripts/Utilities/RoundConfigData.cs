using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SJJ.GoogleSheetsDatabase;

namespace Game.Database
{
    [CreateAssetMenu(fileName = "RoundConfigData", menuName = "RoundConfigData")]
    public class RoundConfigData : DataContainerBase
    {
        [PageName("roundInfo")]
        public List<RoundData> roundInfo;
    }

    [System.Serializable]
    public class RoundData
    {
        public int round;
        public int monsterId;
        public int spawnNum;
        public int spawnLaneNum;
        public int boss;
        public int bossLane;
    }
}