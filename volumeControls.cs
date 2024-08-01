using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class volumeControls : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;
    public string mixerName;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat(mixerName, 0.8f);
        float sliderValue = slider.value;
        mixer.SetFloat(mixerName, (Mathf.Log10(sliderValue + 0.00000000000000000001f) * 20) );
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetLevel()
    {
        float sliderValue = slider.value;
        mixer.SetFloat(mixerName, (Mathf.Log10(sliderValue + 0.00000000000000000001f) * 20) );
        PlayerPrefs.SetFloat(mixerName, sliderValue);
    }
}
