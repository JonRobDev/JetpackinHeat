using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class menuHS : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        score = SaveSystem.GetInt("Hiscore");
        //Debug.Log(score);
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
