using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiketrap : MonoBehaviour
{

    public SpriteRenderer warningBG;
    public SpriteRenderer warningSymb;

    public Rigidbody2D spikes;

    public float speed;
    public float speedMulti;

    public bool isTrig;
    public bool facingRight;
    public bool isPC;

    // Start is called before the first frame update
    void Start()
    {
        isTrig = false;
        if(isPC == true){
            speedMulti = 1.5f;
        }else{
            speedMulti = 1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        spikes.velocity = new Vector3(speed, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D jeff)
    {
        if(jeff.gameObject.layer == 8 && isTrig == false)
        {
            StartCoroutine(Triggered());
        }
    }

    void ChangeSpeed(float newSpeed){
        
        if(facingRight == true){
        speed = newSpeed;
        }else{
            speed = newSpeed * -1f;
        }
    }

    IEnumerator Triggered()
    {
        warningBG.color = new Color (200, 0, 0, 0.2f);
        warningSymb.color = new Color (255, 255, 255, 1);
        isTrig = true;
        ChangeSpeed(0);
        //Debug.Log(speed);
        yield return new WaitForSeconds(2);
        warningBG.color = new Color (200, 0, 0, 0);
        warningSymb.color = new Color (255, 255, 255, 0);
        yield return new WaitForSeconds(1);
        ChangeSpeed(8f * speedMulti);
        //Debug.Log(speed);
        yield return new WaitForSeconds(0.5f);
        ChangeSpeed(-2f * speedMulti);
        //Debug.Log(speed);
        yield return new WaitForSeconds(2f);
        ChangeSpeed(0);
         //Debug.Log(speed);
         isTrig = false;
    }
}
