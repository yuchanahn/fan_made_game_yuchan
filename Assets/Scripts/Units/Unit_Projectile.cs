using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Projectile : MonoBehaviour
{
    private float damage;
    private float speed;

    private void Awake()
    {
        Destroy(gameObject, 5f);
    }

    private void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Unit"))
        {
            Destroy(gameObject);
        }
    }

    public void Initialize(float dmg, float spd)
    {
        damage = dmg;
        speed = spd;
    }
}
