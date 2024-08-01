using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upgradeSystem : MonoBehaviour
{
    public gameFactors gF;

    public Text upgradeText;
    public Text upgradeName;
    public TextAsset[] languages;
    public Text price;

    public int[] priceValues;
    public int coins;
    public float playerSpeedMulti;
    public float enemySpeedMulti;
    public float DMGFactor;
    public float fireRate;
    public float sizeMulti;
    public float fireDMG;
    public float bulletSizeMulti;
    public int health;
    public float bulletSpeed;
    public int invincibilityTime;

    public int activeUpgrade;

    public int currentLang;
    public string[] shite;

    public Button upgradeBTN;

    public languageManager lM;
    // Start is called before the first frame update
    void Start()
    {
        upgradeText.text = "";
        upgradeName.text = "";
        price.text = "";
         
        gF = GameObject.FindObjectOfType<gameFactors>();
        lM = GameObject.FindObjectOfType<languageManager>();

        if (SaveSystem.GetInt("Upgrade0") < 100 || SaveSystem.GetInt("Upgrade1") < 50)
        {
            SaveSystem.SetInt("Upgrade" + 0, 125);
            SaveSystem.SetInt("Upgrade" + 1, 75);
            SaveSystem.SetInt("Upgrade" + 2, 100);
            SaveSystem.SetInt("Upgrade" + 3, 55);
            SaveSystem.SetInt("Upgrade" + 4, 85);
            SaveSystem.SetInt("Upgrade" + 5, 80);
            SaveSystem.SetInt("Upgrade" + 6, 95);
            SaveSystem.SetInt("Upgrade" + 7, 900);
        }

        for (int i = 0; i < priceValues.Length; i++){
            priceValues[i] = SaveSystem.GetInt("Upgrade" + i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        coins = SaveSystem.GetInt("Coins");

        if (coins < priceValues[activeUpgrade])
        {
            upgradeBTN.interactable = false;
        }
        else
        {
            upgradeBTN.interactable = true;
        }

        split = (languages[currentLang].text.Split('\n'));

        if(SaveSystem.GetInt("Upgrade0") < 100 || SaveSystem.GetInt("Upgrade1") < 50){
            SaveSystem.SetInt("Upgrade" + 0, 125);
            SaveSystem.SetInt("Upgrade" + 1, 75);
            SaveSystem.SetInt("Upgrade" + 2, 100);
            SaveSystem.SetInt("Upgrade" + 3, 55);
            SaveSystem.SetInt("Upgrade" + 4, 85);
            SaveSystem.SetInt("Upgrade" + 5, 80);
            SaveSystem.SetInt("Upgrade" + 6, 95);
            SaveSystem.SetInt("Upgrade" + 7, 90);
        }

        currentLang = lM.lang;

        health = SaveSystem.GetInt("HP");
        playerSpeedMulti = SaveSystem.GetFloat("playerSpeedMulti");
        fireRate = SaveSystem.GetFloat("fireRate");
        sizeMulti = SaveSystem.GetFloat("sizeMulti");
        DMGFactor = SaveSystem.GetFloat("DMGMulti");
        bulletSizeMulti = SaveSystem.GetFloat("bulletSizeRate");
        bulletSpeed = SaveSystem.GetFloat("bulletSpeedMulti");
        enemySpeedMulti = SaveSystem.GetFloat("enemySpeedMulti");
        invincibilityTime = SaveSystem.GetInt("invincibilityTime");

        /* for(int i = 0; i < priceValues.Length; i++){
            if(coins < priceValues[i]){
                upgradeBTNs[i].interactable = false;
            }
            else{
                upgradeBTNs[i].interactable = true;
            }
        }
        */
    }

    public void Buy()
    {
        if (coins >= priceValues[activeUpgrade])
        {
            //Debug.Log("Coins BEFORE: " + coins);
            //Debug.Log(priceValues[activeUpgrade]);
            coins = coins - priceValues[activeUpgrade];
            //Debug.Log("Coins NOW: " + coins);
            SaveSystem.SetInt("Coins", coins);
            priceValues[activeUpgrade] = Mathf.RoundToInt(Mathf.Pow(priceValues[activeUpgrade], 1.15f) *.8525f);
            SaveSystem.SetInt("Upgrade" + activeUpgrade, priceValues[activeUpgrade]);
            //Debug.Log(SaveSystem.GetInt("Upgrade" + activeUpgrade));
        }

        int x = activeUpgrade;

        if (currentLang == 0)
        {
            price.text = "PRICE: " + priceValues[x].ToString() + "₴";
        }
        if (currentLang == 1)
        {
            price.text = "PRECIO: " + priceValues[x].ToString() + "₴";
        }
        if (currentLang == 2)
        {
            price.text = "PREZZO: " + priceValues[x].ToString() + "₴";
        }
        if (currentLang == 3)
        {
            price.text = "ЦЕНА: " + priceValues[x].ToString() + "₴";
        }
    }

    public void yomama(string niggers){
        string[] splittedParams = niggers.Split(' ');

        int x = int.Parse(splittedParams[0]);
        int descNum = int.Parse(splittedParams[1]);
        int itemName = int.Parse(splittedParams[2]);

        /* 
            if (coins >= priceValues[x]){
                //Debug.Log("Coins BEFORE: " + coins);
                //Debug.Log( priceValues[x]);
                coins = coins - priceValues[x];
                //Debug.Log("Coins NOW: " + coins);
                SaveSystem.SetInt("Coins", coins );
                priceValues[x] = Mathf.RoundToInt(Mathf.Pow( priceValues[x], 1.175f)); 
                SaveSystem.SetInt("Upgrade" + x, priceValues[x]);
                //Debug.Log( SaveSystem.GetInt("Upgrade" + x));
            }
        */

        upgradeText.text = shite[descNum];
       upgradeName.text = shite[itemName];

        activeUpgrade = x;

        if (currentLang == 0)
        {
            price.text = "PRICE: " + priceValues[x].ToString() + "₴";
        }
        if (currentLang == 1)
        {
            price.text = "PRECIO: " + priceValues[x].ToString() + "₴";
        }
        if (currentLang == 2)
        {
            price.text = "PREZZO: " + priceValues[x].ToString() + "₴";
        }
        if (currentLang == 3)
        {
            price.text = "ЦЕНА: " + priceValues[x].ToString() + "₴";
        }

        if ( x == 0 ){
            SaveSystem.SetInt("Health" + 0, health + 1);
        } else if(x == 1){
            SaveSystem.SetFloat("fireRate" + 0, fireRate - 0.075f);
            SaveSystem.SetFloat("bulletSpeedMulti" + 0, bulletSpeed + 3f);
        } else if(x == 2){
            SaveSystem.SetFloat("playerSpeedMulti" + 0, playerSpeedMulti + 0.1f);
        } else if(x == 3){
            SaveSystem.SetFloat("sizeMulti" + 0, sizeMulti - 0.035f);
        }else if(x == 4){
            SaveSystem.SetFloat("bulletSizeMulti" + 0, bulletSizeMulti + 0.075f);
        }else if(x == 5){
            SaveSystem.SetFloat("enemySpeedMulti" + 0, enemySpeedMulti - 0.025f);
        }else if(x == 6){
            SaveSystem.SetFloat("DMGMulti" + 0, DMGFactor + .25f);
        }else if(x == 7){
            SaveSystem.SetFloat("invincibilityTime" + 0, invincibilityTime + .5f);
        }
        
    }
}
