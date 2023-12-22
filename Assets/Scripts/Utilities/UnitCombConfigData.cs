using System.Collections;
using System.Collections.Generic;
using Game.Database;
using SJJ.GoogleSheetsDatabase;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitCombConfigData", menuName = "ConfigData/UnitCombConfigData")]
public class UnitCombConfigData : DataContainerBase
{
    [PageName("Unit_Comb")]
    public List<RecipeData> unit_Comb;
}

[System.Serializable]
public class RecipeData
{
    public string unitName;
    public string unitGrade;
    public string mainComb;
    public string subComb1;
    public string subComb2;
    public string subComb3;
    public string subComb4;
    public string subComb5;
    public float point;
}