using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public cannonScript cannonObj;
    public playerMovement player;
    public float cannonRotation;
    Vector3 worldPoint;

    public gameFactors gF;
    // Start is called before the first frame update
    void Start()
    {
        cannonObj = GameObject.FindObjectOfType<cannonScript>();
        player = GameObject.FindObjectOfType<playerMovement>();
        gF = GameObject.FindObjectOfType<gameFactors>();

        worldPoint = player.worldPoint;
        cannonRotation = cannonObj.cannonRot;

        Vector3 touchPos = player.touchPos;
        Vector3 difference = touchPos - cannonObj.transform.position;
        float distance = difference.magnitude;
        Vector3 direction = difference / distance;

        transform.localScale = new Vector2(1.25f * gF.bulletSizeMulti, 1.25f * gF.bulletSizeMulti);

        rb2d.velocity = direction * (gF.bulletSpeed / gF.bulletSizeMulti);
        Debug.Log(rb2d.velocity);

    }

    // Update is called once per frame
    void Update()
    {
       

    }

    void OnCollisionEnter2D(Collision2D lol){
        if(lol.gameObject.name == "Frame" || lol.gameObject.name == "Borders"){
            Destroy(this.gameObject);
        }
    }
}
