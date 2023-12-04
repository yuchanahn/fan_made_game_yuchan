using Game.Database;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Unit))]
public class UnitInitializer : MonoBehaviour
{
    [SerializeField] private UnitConfigData unitConfigData;
    
    [SerializeField] private int unitID;

    private Unit unit;

    private void Awake()
    {
        if (unit == null)
            unit = GetComponent<Unit>();

        var data = unitConfigData.Unit_CSV.First(d => d.unitID == unitID);

        unit.Initialize(data);
    }
}
