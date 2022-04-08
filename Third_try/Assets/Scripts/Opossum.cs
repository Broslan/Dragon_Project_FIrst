using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opossum : Enemy
{
    [SerializeField] private LayerMask layerWall;
    void Start()
    {
        initialize();
        //Debug.Log("LayerMask = " + layerWall.value);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ReachWall(collision);
       
        //anim.speed = 0f;
    }
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    NearWall(collision);
    //    Debug.Log("TriggerStay");
    //}

    void Update()
    {
        if(wallInReach) NearWall(collisionCache);
    }
}
