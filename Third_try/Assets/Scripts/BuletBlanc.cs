using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuletBlanc : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] protected int gunNum = 0;
    [SerializeField] protected float movSpeed = 20f;
    [SerializeField] protected float damage = 40;
    [SerializeField] protected GameObject destroyEffect;
    [SerializeField] protected float bulletDestroy = 3f;
    [SerializeField] Upgrade upgradeinfo;

    protected virtual void OnStart() 
    {
        rb = GetComponent<Rigidbody2D>();
        damage = damage * upgradeinfo.DmgMod(gunNum);
        rb.velocity = transform.right * movSpeed;
        Destroy(gameObject, bulletDestroy);
    }

    protected virtual void ForTriggerEnter(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Instantiate(destroyEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    
}
