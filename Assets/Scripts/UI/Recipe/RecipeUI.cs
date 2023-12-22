using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Game.Database;

public class RecipeUI : MonoBehaviour
{
    Unit currentSelectedUnit = null;
    
    [SerializeField] private VerticalBox recipeBox = null;
    [SerializeField] private GameObject recipeSlotPrefab = null;
    [SerializeField] private UnitCombConfigData unitCombConfigData;
    private void Awake()
    {
        recipeBox = GetComponentInChildren<VerticalBox>();
    }

    private void Update()
    {
        if(currentSelectedUnit != GameInstance.Instance.currentSelectedUnit)
        {
            currentSelectedUnit = GameInstance.Instance.currentSelectedUnit;
            UpdateRecipe();
        }
    }

    private void UpdateRecipe()
    {
        if (currentSelectedUnit == null) return;

        foreach (Transform child in recipeBox.content)
        {
            Destroy(child.gameObject);
        }
        
        unitCombConfigData.unit_Comb
            .Where(d => d.mainComb == currentSelectedUnit.unitName)
            .ToList()
            .ForEach(data => AddRecipe(data));
    }
    
    private void AddRecipe(RecipeData data)
    {
        var slot = Instantiate(recipeSlotPrefab, recipeBox.content);
        slot.GetComponent<RecipeSlot>().Initialize(data);
    }
}
