using Game.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Draggable), typeof(BoxCollider2D))]
public class Unit : MonoBehaviour
{
    private string unitName;
    private string skillName;
    private int unitID;
    private EUNITGRADE unitGrade;
    private float attackRange;
    private int attackLine;
    private float damage;
    private float attackSpeed;
    private float projectileSpeed;

    public GameObject bulletPrefab;

    private float originalDamage;
    private float lastShootTime;

    public event Action OnShoot;

    private void Start()
    {
        originalDamage = damage;
        lastShootTime = Time.time;
    }

    private void Update()
    {
        if (Time.time - lastShootTime >= attackSpeed)
        {
            Shoot();
            lastShootTime = Time.time;
        }
    }

    private void Shoot()
    {
        for (int i = 0; i < attackRange; i++)
        {
            Unit_Projectile bullet = Instantiate(bulletPrefab, GetBulletSpawnPosition(i), Quaternion.identity).GetComponent<Unit_Projectile>();
            bullet.Initialize(damage, projectileSpeed);
        }

        OnShoot?.Invoke();
    }

    private Vector3 GetBulletSpawnPosition(int line)
    {
        float lineHeight = 0.7f; // ���� ���� ���� �Ÿ� (���ӿ� �°� ���� �ʿ�)

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

    public void ModifyProjectileDamage(float multiplier)
    {
        damage *= multiplier;
    }

    public void ResetProjectileDamage()
    {
        damage = originalDamage;
    }
}
