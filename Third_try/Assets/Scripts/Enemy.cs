using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected GameObject walls;
    [SerializeField] protected float startHealth;
    protected float health;
    [SerializeField] protected GameObject deathEffect;
    //[SerializeField] protected Transform stopPoint;
    [SerializeField] protected float runSpeed;
    [SerializeField] protected float attackDamage;
    [SerializeField] protected float attackSpeed;
    protected float attcakTimer;
    protected Collider2D collisionCache;
    [SerializeField] protected Upgrade upgeadeInfo;
    [SerializeField] protected int deathCost;
    protected GameObject wallFinded;

    protected Animator anim;
    protected Rigidbody2D rb;

    protected bool wallInReach = false;
    //[SerializeField] protected LayerMask layerWall;


    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
            upgeadeInfo.moneyAmmount += deathCost;
            MoneyUpd();
            Destroy(gameObject);
            //death = true;
        }
    }

    protected void initialize()
    {
        health = startHealth;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * runSpeed;
        anim = GetComponent<Animator>();
        attcakTimer = attackSpeed;
        wallFinded = GameObject.FindGameObjectWithTag("Wall");
    }
    
    protected void ReachWall(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            //Debug.Log("Wall Reached");
            collisionCache = collision;
            rb.velocity = Vector2.zero;
            wallInReach = true;
            anim.SetBool("IsNearWall", true);
        }
    }

    protected void NearWall(Collider2D collision)
    {
        if(attcakTimer <= 0f)
        {
            //Debug.Log("Attack");
            attcakTimer = attackSpeed;
            AttackWall(collision);
        }
        else
        {
            attcakTimer -= Time.deltaTime;
        }
    }

    protected void AttackWall(Collider2D collision)
    {
        TheWallScript wall = collision.GetComponent<TheWallScript>();
        if (wall != null)
        {
            wall.TakeDamage(attackDamage); 
        }
    }

    protected void MoneyUpd()
    {
        TheWallScript theWall = wallFinded.GetComponent<TheWallScript>();
        theWall.TxtUpd();
    }
}

