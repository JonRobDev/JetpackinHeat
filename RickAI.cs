using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class RickAI : MonoBehaviour
{
    public float speedX;
    public float speedY;
    public Rigidbody2D rb2d;
    private playerMovement player;
    public float health;
    public SpriteRenderer lol;

    public AudioSource sfx;

    public gameFactors gF;

    public float rotation;
    // Start is called before the first frame update
    void Start()
    {
        gF = GameObject.FindObjectOfType<gameFactors>();
        health = Random.Range(2.25f, 3.75f);
        speedX = Random.Range(9f, 16f);
        speedX = speedX * gF.enemySpeedMulti;
        speedY = speedX;

        player = GameObject.FindObjectOfType<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector3(speedX, speedY, 0);
        transform.rotation = Quaternion.Euler(0, 0, rotation++);

            if(player.health <= 0){
                Destroy(this.gameObject);
            }

            
    if(health <= 0){
        player.score++;
        
        Destroy(gameObject);
    }
    }

    void OnCollisionEnter2D (Collision2D other){
        if(other.gameObject.name == "Frame"){
            speedX = speedX * -1;
            //Debug.Log("OHHHHH YOU HIT THE FRAME");
            sfx.Play();
        }
        if(other.gameObject.name == "Borders"){
            speedY = speedY * -1;
            //Debug.Log("OHHHHH YOU HIT THE BORDER");
            sfx.Play();
        }

        if(other.gameObject.layer == 10)
        {
            StartCoroutine(Hurt());
            //Debug.Log(health);
            Destroy(other.gameObject);
        }
    }

        IEnumerator Hurt()
    {
        lol.color = new Color (200, 0, 0, 0.9f);
        health--;
        yield return new WaitForSeconds(0.125f);
        lol.color = new Color (255, 255, 255, 1f);

    }
}
