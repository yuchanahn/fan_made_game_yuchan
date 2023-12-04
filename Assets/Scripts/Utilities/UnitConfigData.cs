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
        UNIQUE,
        LEGENDARY,
        IMMORTAL,
        WAK,
        ISEDOL,
        HIDDEN,
    }

    [CreateAssetMenu(fileName = "UnitConfigData", menuName = "UnitConfigData")]
    public class UnitConfigData : DataContainerBase
    {
        [PageName("Unit_CSV")]
        public List<UnitData> Unit_CSV;
        [PageName("Unit_ToolTip_Info")]
        public List<UnitSkillData> Unit_ToolTip_Info;
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

        [TextArea(5, 5)]
        public string skillDescription;
        public string skillLineDescription;
    }
}