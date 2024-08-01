using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyMobile;
using UnityEngine.SceneManagement;

public class InterstitialAds : MonoBehaviour
{
    // Start is called before the first frame update
    public int counter;
    void Start()
    {
        DontDestroyOnLoad(this);
        bool isReady = Advertising.IsInterstitialAdReady();

        if (counter >= 5 && isReady == true)
        {
            Advertising.ShowInterstitialAd();
            Time.timeScale = 0;
            counter = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "MainGame")
        {
            if(Time.deltaTime >= 45f)
            {
                Invoke("upOne", 0.25f);
            }
        }
    }

    // Subscribe to the event
    void OnEnable()
    {
        Advertising.InterstitialAdCompleted += InterstitialAdCompletedHandler;
    }

    void upOne()
    {
        counter++;
    }

    // The event handler
    void InterstitialAdCompletedHandler(InterstitialAdNetwork network, AdLocation location)
    {
        Debug.Log("Interstitial ad has been closed.");
        Time.timeScale = 1;
    }

    // Unsubscribe
    void OnDisable()
    {
        Advertising.InterstitialAdCompleted -= InterstitialAdCompletedHandler;
    }
}
