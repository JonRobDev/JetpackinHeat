using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public shuteyeAI shuteyeOBJ;
    public float roboRotation;
    public GameObject p;
    public Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        shuteyeOBJ = GameObject.FindObjectOfType<shuteyeAI>();
        p = GameObject.Find("Player");
        target = p.transform.position + new Vector3(Random.Range(-0.25f, 0.25f), Random.Range(-0.25f, 0.25f), 0);

        Vector3 difference = target - transform.position;
        float distance = difference.magnitude;
        Vector3 direction = difference/distance;

        rb2d.velocity = direction * 20;

        //Debug.Log("Velocity: " + rb2d.velocity);

        Invoke("DestroyThis", 2.5f);
    }

    private void DestroyThis(){
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D lol){
        if(lol.gameObject.name == "Frame" || lol.gameObject.name == "Borders"){
            Destroy(this.gameObject);
        }
    }
}
