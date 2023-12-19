using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chimp_Skill : MonoBehaviour
{
    private Unit unit;
    private int shootCount = 0;
    private float damageMultiplier = 1.05f;

    void Start()
    {
        unit = GetComponent<Unit>();
        if (unit != null)
        {
            unit.OnShoot += HandleUnitShoot;
        }
    }

    private void HandleUnitShoot()
    {
        shootCount++;
        if (shootCount % 5 == 0)
        {
            unit.ModifyProjectileDamage(damageMultiplier);
        }
        else
        {
            unit.ResetProjectileDamage();
        }
    }

    void OnDestroy()
    {
        if (unit != null)
        {
            unit.OnShoot -= HandleUnitShoot; // 이벤트 구독 해제
        }
    }
}
