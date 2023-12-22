using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    static RaycastHit2D CastRay2D()
    {
        Vector3 screenMousePos = Input.mousePosition;
        Vector2 worldMousePos = Camera.main.ScreenToWorldPoint(screenMousePos);

        return Physics2D.Raycast(worldMousePos, Vector2.zero);
    }

    void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        
        var hit = CastRay2D();
        var hitCollider = hit.collider;
        
        if (!hitCollider || !hitCollider.gameObject.GetComponent<Unit>()) return;
        
        var unit = hitCollider.gameObject.GetComponent<Unit>();
        GameInstance.Instance.currentSelectedUnit = unit;
        Debug.Log("Slot Clicked : " + unit.unitName);
    }
}
