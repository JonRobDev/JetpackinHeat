using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shuteyeAI : MonoBehaviour
{
    private GameObject target;
    public GameObject bulletPrefab;
    public float angle;
    public Transform shootTranform;
    public float speed;
    bool canShoot;
    public bool isTriggered;
    public AudioSource audio;
    private playerMovement player;
    public float health;
    public SpriteRenderer lol;
    public Vector3 worldPoint;
    public Vector3 playerTrigPoint;

    public gameFactors gF;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<playerMovement>();
        target = GameObject.Find("Player");

        health = Random.Range(2.25f, 3.25f);

        gF = GameObject.FindObjectOfType<gameFactors>();

        canShoot = true;

        speed = speed * gF.enemySpeedMulti;
    }

    // Update is called once per frame
    void Update()
    {
    worldPoint = Camera.main.ScreenToWorldPoint(transform.position);

    if(isTriggered == false){
        angle = Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
    } else if (isTriggered == true){
         angle = Mathf.Atan2(playerTrigPoint.y - transform.position.y, playerTrigPoint.x - transform.position.x) * Mathf.Rad2Deg;
    }

    transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    if(Vector2.Distance(transform.position, target.transform.position) >= 2.5)
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    if(player.health <= 0){
        Destroy(gameObject);
    }

    if(health <= 0){
        player.score++;
        
        Destroy(gameObject);
    }
    }

    void Shoot()
    {
        if (canShoot == true)
        {
            audio.Play();
            GameObject laser = (GameObject)Instantiate(bulletPrefab, shootTranform.position, Quaternion.Euler(0, 0, Mathf.Atan2(playerTrigPoint.y - shootTranform.position.y, playerTrigPoint.x - shootTranform.position.x) * Mathf.Rad2Deg));
            laser.name = "LASER";
            canShoot = false;
        }
    }

    void OnTriggerEnter2D(Collider2D jeff)
    {
        if(jeff.gameObject.layer == 8)
        {
            playerTrigPoint = jeff.gameObject.transform.position;
            //Debug.Log(playerTrigPoint);
            StartCoroutine(ShuteyeShoot());
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

    IEnumerator ShuteyeShoot()
    {
        speed = 0;
        isTriggered = true;
        yield return new WaitForSeconds(1/6f);
        Shoot();
        yield return new WaitForSeconds(2);
        speed = 3;
        canShoot = true;
        isTriggered = false;
    }

    IEnumerator Hurt()
    {
        lol.color = new Color (200, 0, 0, 0.9f);
        health = health - gF.DMGFactor;
        yield return new WaitForSeconds(0.125f);
        lol.color = new Color (255, 255, 255, 1f);

    }
}
