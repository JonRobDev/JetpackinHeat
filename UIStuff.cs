using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIDumbShit : MonoBehaviour
{
    public GameObject shop;
    public GameObject loadingThing;
    public GameObject settings;

    public AudioSource menuMusics;
    public AudioSource shopMusics;

    public gameFactors gF;
    bool loading;
    // Update is called once per frame

    void Start(){

        gF = GameObject.FindObjectOfType<gameFactors>();

        loadingThing.SetActive(false);
        shop.SetActive(false);
        settings.SetActive(false);
    }
    void Update()
    {
        if( loading == true ){
            loadingThing.SetActive(true);
        }
    }

    public void StartGame(){
        loading = true;
        //s(loadingThing.activeSelf);
         StartCoroutine(loadShit( "MainGame" ) );
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void RestartGame(){
         SceneManager.LoadScene("MainGame");
    }

    public void BackToMenu(){
        loading = true;
         //Debug.Log(loadingThing.activeSelf);
         Destroy(gF);
         StartCoroutine(loadShit( "MainMenu" ) );
    }

    public void OpenShop(){
        menuMusics.volume = 0;
        if(shopMusics.isPlaying == false) shopMusics.Play();
        shopMusics.volume = 0.8f;
        shop.SetActive(true);
    }

    public void CloseShop(){
        shopMusics.volume = 0;
        menuMusics.volume = 1f;
        shop.SetActive(false);
    }

    public void OpenSettings(){
        settings.SetActive(true);
    }

    public void CloseSettings(){
        settings.SetActive(false);
    }

    IEnumerator loadShit(string scene){
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(scene);
    }

}
