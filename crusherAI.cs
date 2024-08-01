using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class crusherAI : MonoBehaviour
{
public SpriteRenderer warningBG;
    public SpriteRenderer warningSymb;

    public Rigidbody2D spikes;
    public playerMovement player;
    public SpriteRenderer lol;
    public int force;
    public float speed;
    public float health;
    public bool isTrig;
    public bool facingRight;

    public AudioSource sfx;

    public gameFactors gF;

    // Start is called before the first frame update
    void Start()
    {
        gF = GameObject.FindObjectOfType<gameFactors>();

        isTrig = false;
        health = Random.Range(2.25f, 3.75f);
        player = GameObject.FindObjectOfType<playerMovement>();


        speed = speed * gF.enemySpeedMulti;
    }

    // Update is called once per frame
    void Update()
    {
        spikes.velocity = new Vector3(force, speed, 0);

        if(player.health <= 0){
            Destroy(gameObject);
        }

        if(health <= 0){
            player.score++;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D jeff)
    {
        if(jeff.gameObject.layer == 8 && isTrig == false)
        {
            StartCoroutine(Triggered());
        }

         if(jeff.gameObject.layer == 0)
        {
            speed = speed * -1;
        }
    }

    void OnCollisionEnter2D (Collision2D bob)
    {
        Debug.Log("IT WORKS");
        if(bob.gameObject.layer == 10)
        {
            StartCoroutine(Hurt());
            Debug.Log(health);
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

    void ChangeForce(int newForce){
        if(facingRight == true){
        force = newForce;
        }else{
        force = newForce * -1;
        }
    }

    IEnumerator Triggered()
    {
        speed = 0;
        warningBG.color = new Color (200, 0, 0, 0.2f);
        warningSymb.color = new Color (255, 255, 255, 1);
        isTrig = true;
        ChangeForce(0);
        Debug.Log(force);
        yield return new WaitForSeconds(0.75f);
        warningBG.color = new Color (200, 0, 0, 0);
        warningSymb.color = new Color (255, 255, 255, 0);
        yield return new WaitForSeconds(0.5f);
        sfx.Play();
        ChangeForce(30);
        Debug.Log(force);
       yield return new WaitForSeconds(0.5f);
        ChangeForce(-30);
        Debug.Log(force);
       yield return new WaitForSeconds(0.5f);
        ChangeForce(0);
        Debug.Log(force);
        speed = -5;
        yield return new WaitForSeconds(2);
        isTrig = false;
    }
}
