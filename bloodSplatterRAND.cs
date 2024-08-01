using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloodSplatterRAND : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] bloodSplatters;
    public SpriteRenderer sR;
    void Start()
    {
        sR.sprite = bloodSplatters[Random.Range( 0, 7 ) ];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
