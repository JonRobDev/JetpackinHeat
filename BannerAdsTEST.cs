using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyMobile;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class BannerAdsTEST : MonoBehaviour
{

    // Start is called before the first frame update
    private BannerView bannerView;

    public int interstitCounter;

    void Start()
    {
        #if UNITY_ANDROID
            string appId = "ca-app-pub-3825351577720804~1558816760";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        //MobileAds.Initialize(appId);
        MobileAds.Initialize(initStatus => { });

        this.RequestBanner();

    }

    void Awake(){
        if (!RuntimeManager.IsInitialized()){
            RuntimeManager.Init();
        }
        ShowBannerAds();
    }

    // Update is called once per frame
    public void ShowBannerAds()
    {
        if( SceneManager.GetActiveScene().name == "MainMenu"){
            Advertising.ShowBannerAd(BannerAdPosition.Bottom);
        } else if(  SceneManager.GetActiveScene().name == "MainGame"){
            Advertising.ShowBannerAd(BannerAdPosition.Top);
        }
    }
    private void RequestBanner()
    {
        #if UNITY_ANDROID
            string adUnitId= "ca-app-pub-3825351577720804/3658366493";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
    }
}
