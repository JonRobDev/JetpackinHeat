using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    public GameObject[] spawnOpts;

    public Transform spawnPoint;
    public int num;
    public int spawnTime;

    public int timerRangeA;
    public int timerRangeB;

    public playerMovement target;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindObjectOfType<playerMovement>();

        spawnTime = Random.Range(timerRangeA, timerRangeB);
        InvokeRepeating("Spawn", Random.Range(5, 25), spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        if(target.health > 0){
        num = Random.Range(0, spawnOpts.Length - 1);
        Instantiate(spawnOpts[num], spawnPoint.position, spawnPoint.rotation);
        spawnTime = Random.Range(timerRangeA, timerRangeB);
        }
    }

}
