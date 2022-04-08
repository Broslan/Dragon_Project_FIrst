using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletType_2 : BuletBlanc
{
    // Start is called before the first frame update
    void Start()
    {
        OnStart();
    }

    protected override void ForTriggerEnter(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ForTriggerEnter(collision);
    }
}
