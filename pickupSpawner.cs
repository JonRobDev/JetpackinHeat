using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupSpawner : MonoBehaviour
{

    public GameObject[] spawnOpts;
    public int num;
    public int spawnTime;
    public playerMovement target;

    public int timerRangeA;
    public int timerRangeB;


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
        Vector2 rnd = new Vector2(Random.Range(-10, 10), Random.Range(-20, 20));
        Instantiate(spawnOpts[num], rnd, Quaternion.identity);
        spawnTime = Random.Range(timerRangeA, timerRangeB);
        }
    }
}
