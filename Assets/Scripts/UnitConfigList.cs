using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EUNITGRADE
{
    NORMAL,
    RARE,
}

[CreateAssetMenu(fileName = "UnitConfigList", menuName = "ScriptableObjects/UnitConfigList")]
public class UnitConfigList : ScriptableObject
{
    public string sheetId;
    public string gridId;

    public List<UnitConfig> units = new List<UnitConfig>();

    [ContextMenu("Sync")]
    private void Sync()
    {
        ReadGoogleSheets.FillData<UnitConfig>(sheetId, gridId, unit =>
        {
            units = unit;
            ReadGoogleSheets.SetDirty(this);
        });
    }

    [ContextMenu("OpenSheet")]
    private void Open()
    {
        ReadGoogleSheets.OpenUrl(sheetId, gridId);
    }
}

[Serializable]
public class UnitConfig
{
    public string name;
    public int unitCode = -1;
    public EUNITGRADE unitGrade;
    public float attackRange;
    public int attackLine;
    public float damage;
    public float attackSpeed;
}