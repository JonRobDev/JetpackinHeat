using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goreChunks : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float thrust;
    public Vector3 impulse;

    public GameObject bloodSpooty;

    // Start is called before the first frame update
    void Start()
    {
        thrust = Random.Range(-16, 16);
        impulse = new Vector3(thrust, Random.Range( -5, 25 ), 0.0f);
        rb2d.AddForce(impulse, ForceMode2D.Impulse);
        rb2d.gravityScale = Random.Range(0.5f, 4f);
        this.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360) );

        InvokeRepeating("bloodSpatters", 0.125f, 0.06f);
    }

    public void bloodSpatters(){
            float scaleNum = Random.Range(0.75f, 4f);
            bloodSpooty.gameObject.transform.localScale = new Vector3(scaleNum, scaleNum, 1);
            Instantiate(bloodSpooty, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
