using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trinketTimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(timer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator timer(){
     yield return new WaitForSeconds(5);
     Destroy(gameObject);
    }
}
