using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonScript : MonoBehaviour
{

    public GameObject bulletPrefab;

    public AudioSource audio;

    public Transform shootTranform;

    public GameObject cannonObj;

    public float cannonRot;

    public gameFactors gF;
    public float shootingSpeed;

    public playerMovement bob;

    public bool canShoot;


    // Start is called before the first frame update
    void Start()
    {
        gF = GameObject.FindObjectOfType<gameFactors>();
        bob = GameObject.FindObjectOfType<playerMovement>();
        shootingSpeed = gF.fireRate;
        canShoot = true;
        Invoke("Shoot", shootingSpeed + .125f);

    }

    // Update is called once per frame
    void Update()
    {

        cannonRot = cannonObj.transform.eulerAngles.z;
        if(bob.health <= 0) canShoot = false;

    }

    void Shoot()
    {
        if (Input.touchCount > 1 && Application.platform == RuntimePlatform.Android)
        {
            if(canShoot == true){
            audio.Play();
            Instantiate(bulletPrefab, shootTranform.position, shootTranform.rotation);
            Invoke("Shoot", shootingSpeed + .1f);
            }

        }else{

            if(canShoot == true){
            audio.Play();
            Instantiate(bulletPrefab, shootTranform.position, shootTranform.rotation);
            Invoke("Shoot", shootingSpeed + .1f);
            }

        }
    }

}
