using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SJJ.GoogleSheetsDatabase;

namespace Game.Database
{
    public enum EUNITGRADE
    {
        NORMAL,
        RARE,
    }

    [CreateAssetMenu(fileName = "UnitConfigData", menuName = "UnitConfigData")]
    public class UnitConfigData : DataContainerBase
    {
        [PageName("Unit_CSV")]
        public List<UnitData> unitData;
        [PageName("Unit_ToolTip_Info")]
        public List<UnitSkillData> unitSkillData;
    }

    [System.Serializable]
    public class UnitData
    {
        public string unitName;
        public int unitID;
        public EUNITGRADE unitGrade;
        public float attackRange;
        public int attackLine;
        public int damage;
        public float attackSpeed;
    }

    [System.Serializable]
    public class UnitSkillData
    {
        public string unitName;
        public EUNITGRADE unitGrade;
        public float attackRange;

        [TextArea(10, 10)]
        public string skillDescription;
    }
}