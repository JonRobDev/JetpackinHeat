﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lankinAI : MonoBehaviour
{

    private GameObject target;
    public float angle;
    public float speed;
    public AudioSource audio;
    private playerMovement player;
    public float health;
    public SpriteRenderer lol;
    public Vector3 worldPoint;
    public float waitAngle;

    public Transform saw;

    public gameFactors gF;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<playerMovement>();
        gF = GameObject.FindObjectOfType<gameFactors>();
        target = GameObject.Find("Player");
        health = Random.Range(1.25f, 2.25f);

        speed = speed * gF.enemySpeedMulti;
    }

    // Update is called once per frame
    void Update()
    {
        worldPoint = Camera.main.ScreenToWorldPoint(transform.position);

        angle = Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x) * Mathf.Rad2Deg;

        int niggas = 0;
        niggas++;

        //transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        saw.rotation = Quaternion.Euler(new Vector3(0, 0, Time.time * 2.5f));
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, angle)), Time.time * 0.05f);

        if (Vector2.Distance(transform.position, target.transform.position) >= 2.5)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }

        if (player.health <= 0)
        {
            Destroy(gameObject);
        }

        if (health <= 0)
        {
            player.score++;

            Destroy(gameObject);
        }
    }

    IEnumerator Hurt()
    {
        lol.color = new Color(200, 0, 0, 0.9f);
        health = health - gF.DMGFactor;
        yield return new WaitForSeconds(0.125f);
        lol.color = new Color(255, 255, 255, 1f);

    }

    void OnCollisionEnter2D(Collision2D bob)
    {
        //Debug.Log("IT WORKS");
        if (bob.gameObject.layer == 10)
        {
            StartCoroutine(Hurt());
            //Debug.Log(health);
            Destroy(bob.gameObject);
        }
    }
}
