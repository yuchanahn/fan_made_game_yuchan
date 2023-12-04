using Game.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Draggable), typeof(BoxCollider2D))]
public class Unit : MonoBehaviour
{
    private string unitName;
    private int unitID;
    private EUNITGRADE unitGrade;
    private float attackRange;
    private int attackLine;
    private int damage;
    private float attackSpeed;
    private float projectileSpeed;

    public GameObject bulletPrefab; // 총알 프리팹

    private void Start()
    {
        if (bulletPrefab != null)
            StartCoroutine(ShootRoutine());
    }

    private IEnumerator ShootRoutine()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(attackSpeed);
        }
    }

    private void Shoot()
    {
        for (int i = 0; i < attackRange; i++)
        {
            Unit_Projectile bullet = Instantiate(bulletPrefab, GetBulletSpawnPosition(i), Quaternion.identity).GetComponent<Unit_Projectile>();
            bullet.Initialize(damage, projectileSpeed);
        }
    }

    private Vector3 GetBulletSpawnPosition(int line)
    {
        float lineHeight = 0.7f; // 라인 간의 수직 거리 (게임에 맞게 조정 필요)

        float verticalPosition = (line - (attackRange - 1) / 2.0f) * lineHeight;

        return transform.position + new Vector3(0, verticalPosition, 0);
    }

    public void Initialize(UnitData data)
    {
        unitName = data.unitName;
        unitID = data.unitID;
        unitGrade = data.unitGrade;
        attackRange = data.attackRange;
        attackLine = data.attackLine;
        damage = data.damage;
        attackSpeed = data.attackSpeed;
        projectileSpeed = data.projectileSpeed;
    }
}
