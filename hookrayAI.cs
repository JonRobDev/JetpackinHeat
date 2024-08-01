using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class hookrayAI : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public playerMovement player;
    public float speed;
    public float health;
    public bool facingRight;
    public SpriteRenderer laser;
    public SpriteRenderer lol;
    public GameObject laserOBJ;

    public AudioSource sfx;

    public gameFactors gF;

    public bool firing;

    // Start is called before the first frame update
    void Start()
    {
        gF = GameObject.FindObjectOfType<gameFactors>();

        health = Random.Range(2.25f, 3.25f);

        player = GameObject.FindObjectOfType<playerMovement>();
        speed = Random.Range(6, 12);
        speed = speed * gF.enemySpeedMulti;

        Invoke("shooty", Random.Range(2, 4));
        laserOBJ.layer = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.health <= 0){
            Destroy(gameObject);
        }

        if(health <= 0){
            player.score++;
            Destroy(gameObject);
        }

        rb2d.velocity = new Vector2(0, speed);

    }

    void OnTriggerEnter2D(Collider2D jeff)
    {
        if(jeff.gameObject.layer == 0)
        {
            speed = speed * -1;
        }
    }

    void OnCollisionEnter2D (Collision2D bob)
    {
        //Debug.Log("IT WORKS");
        if(bob.gameObject.layer == 10)
        {
            StartCoroutine(Hurt());
            //Debug.Log(health);
            Destroy(bob.gameObject);
        }
    }

    IEnumerator Hurt()
    {
        lol.color = new Color (200, 0, 0, 0.9f);
        health = health - gF.DMGFactor;
        yield return new WaitForSeconds(0.125f);
        lol.color = new Color (255, 255, 255, 1f);

    }

    public void shooty(){
        StartCoroutine(LaserFire(Random.Range(4,8 ) ) );
        Invoke("shooty", Random.Range(4,8));
    }

    IEnumerator LaserFire(int timer)
    {
        speed = speed / 2;
        laser.color = new Color(180, 0, 0, 0.2f);
        yield return new WaitForSeconds(0.2f);
        laser.color = new Color(200, 0, 0, 0f);
        yield return new WaitForSeconds(0.2f);
        laser.color = new Color(180, 0, 0, 0.2f);
        yield return new WaitForSeconds(0.2f);
        laser.color = new Color(200, 0, 0, 0f);
        yield return new WaitForSeconds(0.2f);
        laser.color = new Color(180, 0, 0, 0.2f);
        yield return new WaitForSeconds(0.2f);
        laser.color = new Color(220, 0, 0, 0.95f);
        sfx.Play();
        laserOBJ.layer = 11;
        yield return new WaitForSeconds(1.25f);
        laser.color = new Color(200, 0, 0, 0f);
        speed = speed * 2;
        laserOBJ.layer = 2;
    }
}
