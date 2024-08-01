using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioDistortion : MonoBehaviour
{
    public Slider slider;
    public AudioDistortionFilter distorter;

    // Start is called before the first frame update
    void Start()
    {
        if(slider != null) slider.value = PlayerPrefs.GetFloat("audioDistort", 0.666666f);
        distorter.distortionLevel = PlayerPrefs.GetFloat("audioDistort");
    }
    public void SetLevel()
    {
        float sliderValue = slider.value;
        distorter.distortionLevel = sliderValue;
        PlayerPrefs.SetFloat("audioDistort", sliderValue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
