using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using EasyMobile.Demo;

public class playerMovement : MonoBehaviour
{
    public SpriteRenderer lol;

    public GameObject[] organs;
    public GameObject bloodSplatter;
    public GameObject bloodSpooty;

    public BoxCollider2D player;

    public Rigidbody2D rb2D;

    public Vector3 worldPoint;
    public Vector2 touchPos;

    public int health;
    public int score;
    public int speed;

    public GameObject[] hearts;
    public GameObject cannonObj;
    public GameObject deadShit;
    public GameObject bloodSpurt;
    public GameObject borders;

    public ParticleSystem bloods;
     public ParticleSystem fire;
    
    public AudioSource music;
    public AudioClip aliveSong;
    public AudioClip deadSong;

    bool canPlay;
    public bool canBeHurt;

    public TextMeshProUGUI scoreText;

    public float moveInputX;
    public float moveInputY;

    
    public gameFactors gF;

    public int coinsTotal;

    public Text coinText;
    public float scale;

    // Start is called before the first frame update
    void Start()
    {
        gF = GameObject.FindObjectOfType<gameFactors>();
        scale = gF.sizeMulti;
        music.clip = aliveSong;
        music.Play();
        canPlay = true;
        deadShit.SetActive(false);
        canBeHurt = true;
        health = gF.health;
        coinsTotal = SaveSystem.GetInt("Coins");

        fire.Play();

        rb2D.GetComponent<Rigidbody2D>();

        transform.localScale = new Vector2(2.5f * scale, 2.25f * scale);

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            borders.SetActive(false);
        }

        for (int  i = 0; i < health; i++){
            hearts[i].SetActive(true);
        }
        for(int i = health; i < hearts.Length; i++){
             hearts[i].SetActive(false);
        }

        coinsTotal = SaveSystem.GetInt("Coins");
        coinText.text = coinsTotal.ToString();
        scoreText.text = score.ToString();

        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer){
            if (health <= 0 && canPlay == true){

                if(score > SaveSystem.GetInt("Hiscore")){
                SaveSystem.SetInt("Hiscore", score);
                //Debug.Log(SaveSystem.GetInt("Hiscore"));
                }
            
                transform.rotation = Quaternion.Euler(0, 0, 180);
                rb2D.velocity = new Vector3(0, -10, 0);
                //Debug.Log("IT WORKS");
                Invoke("POOP", 0);
                StartCoroutine(deadMenu());
            }else{

        if (Input.touchCount > 0 && health > 0){
                Touch move = Input.GetTouch(0);

            if(move.phase == TouchPhase.Stationary || move.phase == TouchPhase.Moved){
                Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(move.position.x + 0.5f, move.position.y, 10));
                transform.position =  Vector3.Lerp(transform.position, touchedPos, Time.deltaTime * (2.125f * gF.playerSpeedMulti));
            }

            worldPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(1).position);
            touchPos = new Vector2(worldPoint.x, worldPoint.y);

            float angle = Mathf.Atan2(touchPos.y - cannonObj.transform.position.y, touchPos.x - cannonObj.transform.position.x) * Mathf.Rad2Deg;
            cannonObj.transform.rotation = Quaternion.Euler(0, 0, angle);

        }
        }
        }else{
                moveInputX = Input.GetAxis ("Horizontal");
                moveInputY = Input.GetAxis ("Vertical");

                if(moveInputX < 0.1 && moveInputX > -0.1) moveInputX = 0;
                if(moveInputY < 0.1 && moveInputY > -0.1) moveInputY = 0;

                rb2D.velocity = new Vector2 (moveInputX * speed, moveInputY * ( speed * gF.playerSpeedMulti ) );

                transform.rotation = Quaternion.Euler(0, 0, (5f * moveInputX) - (5f * moveInputY));

                worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                touchPos = new Vector2(worldPoint.x, worldPoint.y);

                float angle = Mathf.Atan2(touchPos.y - cannonObj.transform.position.y, touchPos.x - cannonObj.transform.position.x) * Mathf.Rad2Deg;
                cannonObj.transform.rotation = Quaternion.Euler(0, 0, angle);
                if (health <= 0 && canPlay == true){

                if(score > SaveSystem.GetInt("Hiscore")){
                    SaveSystem.SetInt("Hiscore", score);
                    //Debug.Log(SaveSystem.GetInt("Hiscore"));

                    Destroy(borders);
                }

                moveInputX = 0;
                moveInputY = -5;

                //Debug.Log("POOP:" + rb2D.velocity);
            
                transform.rotation = Quaternion.Euler(0, 0, 180);

                rb2D.gravityScale = 100;

                //Debug.Log("IT WORKS");
                Invoke("POOP", 0);
                StartCoroutine(deadMenu());
            }

        }


    }

    public IEnumerator deadMenu(){
        yield return new WaitForSeconds(3);
        deadShit.SetActive(true);
    }

    public IEnumerator bloodSpatters(){
        for( int i = 0; i <= 30; i++){
            yield return new WaitForSeconds(0.06f);
            float scaleNum = Random.Range(1f, 4f);
            bloodSpooty.gameObject.transform.localScale = new Vector3(scaleNum, scaleNum, 1);
            Instantiate(bloodSpooty, transform.position, transform.rotation);
        }
    }

    void POOP(){
        music.clip = deadSong;
        music.pitch = 1;
        music.Play();
        canPlay = false;
    }

    
    IEnumerator Hurt()
    {
        canBeHurt = false;
        player.isTrigger = true;
        lol.color = new Color (200, 0, 0, 0.9f);
        yield return new WaitForSeconds(0.125f);
        lol.color = new Color (255, 255, 255, 0.75f);
        yield return new WaitForSeconds(gF.invincibilityTime);
        lol.color = new Color (255, 255, 255, 1f);
        canBeHurt = true;
        player.isTrigger = false;
    }

    void OnTriggerEnter2D (Collider2D bob)
    {
        //Debug.Log("IT WORKS");
        if(bob.gameObject.layer == 11 && canBeHurt == true)
        {
            health--;
            //Debug.Log(health);
            StartCoroutine(Hurt());
            
            Instantiate(bloodSplatter, transform.position, transform.rotation);
            bloods.Play();

                StartCoroutine(bloodSpatters());

            bloodSpurt.transform.position = new Vector2(this.gameObject.transform.position.x - 0.5f, bob.gameObject.transform.position.y);
            bloodSpurt.transform.eulerAngles = new Vector3(0, 0, Random.Range (0, 360) );
            for( int i = 0; i <= Random.Range(2, 6); i++){
                Instantiate(organs[Random.Range(0, 19)], transform.position, transform.rotation);
            }

            if(bob.gameObject.name == "poop"){
                Destroy(bob.gameObject);
            }
        }

        if(bob.gameObject.layer == 12 && canBeHurt == true){
            health = 0;

            Instantiate(bloodSplatter, transform.position, transform.rotation);
            bloods.Play();

                StartCoroutine(bloodSpatters());

            bloodSpurt.transform.position = new Vector2(this.gameObject.transform.position.x - 0.5f, bob.gameObject.transform.position.y);
            bloodSpurt.transform.eulerAngles = new Vector3(0, 0, Random.Range (0, 360) );
            for( int i = 0; i <= Random.Range(2, 6); i++){
                Instantiate(organs[Random.Range(0, 19)], transform.position, transform.rotation);
            }

            //Debug.Log(health);
        }

        if(bob.gameObject.layer == 13)
        {
            Destroy(bob.gameObject);
            score++;
            coinsTotal++;
            SaveSystem.SetInt("Coins", coinsTotal);
            //Debug.Log(score);
            //Debug.Log("COINZ: " + coinsTotal.ToString());
        }

        if(bob.gameObject.layer == 14)
        {
            Destroy(bob.gameObject);
            if(health < 8)
            {
                health++;
            }

            //Debug.Log(health);
        }
    }

}
