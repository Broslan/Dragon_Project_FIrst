using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    [SerializeField] private Transform centreNode;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Camera cam;
    [SerializeField] private Upgrade upgradeinfo;
    //[SerializeField] private GameObject bullet;
    

    public GameObject[] bullets;
    public int bulletType;

    private Rigidbody2D rb;
    private Vector2 mousPosition;

    private float atkSpeedTimer;
    private float atkSpeedTimeLeft;
    private bool cursorIsFree = true ;
    void Start()
    { 
        rb = GetComponent<Rigidbody2D>();
        bulletType = 0;
        atkSpeedTimeLeft = 0;
        atkSpeedTimer = upgradeinfo.GetAtkSpeed(bulletType);
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseScript.isPaused)
        {
            mousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            Aiming();
            if (Input.GetButton("Fire1"))
            {
                Shoot();
            }
            if (Input.GetKeyDown(KeyCode.Alpha1)) 
            {
                bulletType = 0;
                atkSpeedTimer = upgradeinfo.GetAtkSpeed(bulletType);
            } 
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                bulletType = 1;
                atkSpeedTimer = upgradeinfo.GetAtkSpeed(bulletType);
            }
            //if (Input.GetKeyDown(KeyCode.Alpha7)) bulletType = 2;
            //if (Input.GetKeyDown(KeyCode.Alpha6)) bulletType = 3;
        }
    }
    private void FixedUpdate()
    {
        if (!PauseScript.isPaused)
        {
            if(atkSpeedTimeLeft > 0)
            {
                atkSpeedTimeLeft -= Time.deltaTime;
            }
        }
    }

    private void Aiming()
    {
        Vector2 lookDir = mousPosition - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        centreNode.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void Shoot()
    {
        if (atkSpeedTimeLeft <= 0 && cursorIsFree)
        {
            Instantiate(bullets[bulletType], firePoint.position, firePoint.rotation);
            atkSpeedTimeLeft = atkSpeedTimer;
        }

    }

    public void CursorIsUsed()
    {
        cursorIsFree = false;
    }

    public void CursorIsNotUsed()
    {
        cursorIsFree = true;;
    }
}
