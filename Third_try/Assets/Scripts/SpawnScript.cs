using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    
    public int monsterChoose = 0;
    public GameObject[] monsters;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnInterval;
    private float spawnTimer;

    private void Awake()
    {
        spawnTimer = spawnInterval;
    }
    //void Update()
    //{
    //    if (!PauseScript.isPaused)
    //    {

    //        if (Input.GetKeyDown(KeyCode.Alpha0)) monsterChoose = 0;
    //        if (Input.GetKeyDown(KeyCode.Alpha9)) monsterChoose = 1;
    //        if (Input.GetKeyDown(KeyCode.Alpha3)) monsterChoose = 2;
    //        if (Input.GetKeyDown(KeyCode.Alpha4)) monsterChoose = 3;
    //        if (Input.GetKeyDown(KeyCode.Space))
    //        {
    //            Instantiate(monsters[monsterChoose], transform.position, transform.rotation);
    //        }
    //    }
    //}

    private void FixedUpdate()
    {
        if (!PauseScript.isPaused)
        {
            if (spawnTimer <= 0)
            {
                spawnTimer = spawnInterval;
                int x = Random.Range(0, monsters.Length);
                int y = Random.Range(0, spawnPoints.Length);
                Instantiate(monsters[x], spawnPoints[y].position, Quaternion.identity);
            }
            else
            {
                spawnTimer -= Time.fixedDeltaTime;
            }
        }
    }

}
