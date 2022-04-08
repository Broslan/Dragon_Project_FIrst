using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBooM : MonoBehaviour
{
    const float explosinRadius = 2.5f;
    [SerializeField] private float damage = 100;
    [SerializeField] private LayerMask whatIsDamaged;
    [SerializeField] private GameObject destroyEffect;
    [SerializeField] private float detonationTime;

    private void FixedUpdate()
    {
        if (detonationTime <= 0)
        {
            Boom();
        }
        else
        {
            detonationTime -= Time.deltaTime;
        }
    }

    void Boom()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosinRadius, whatIsDamaged);
        for (int i = 0; i < colliders.Length; i++)
        {
            Enemy enemy = colliders[i].GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
        Instantiate(destroyEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
