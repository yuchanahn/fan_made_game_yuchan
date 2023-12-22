using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RecipeSlot : MonoBehaviour
{
    public string unitName;
    public string unitGrade;
    public string mainComb;
    public string[] subComb;
    public float point;

    private Text recipe;
    
    public void Initialize(RecipeData recipeData)
    {
        unitName = recipeData.unitName;
        unitGrade = recipeData.unitGrade;
        mainComb = recipeData.mainComb;
        subComb = new string[5];
        subComb[0] = recipeData.subComb1;
        subComb[1] = recipeData.subComb2;
        subComb[2] = recipeData.subComb3;
        subComb[3] = recipeData.subComb4;
        subComb[4] = recipeData.subComb5;
        point = recipeData.point;
    }

    private void Awake()
    {
        recipe = GetComponentInChildren<Text>();
    }

    private void Update()
    {
        var result = unitName + "= " + mainComb;
        result = subComb.Where(sub => sub != "").Aggregate(result, (current, sub) => current + (" + " + sub));
        recipe.text = result;
    }
}
