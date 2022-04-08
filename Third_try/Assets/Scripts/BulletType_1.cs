using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletType_1 : BuletBlanc
{
    void Start()
    {
        OnStart();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ForTriggerEnter(collision);
    }
}
