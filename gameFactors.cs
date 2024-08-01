using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameFactors : MonoBehaviour
{

    public float difficultyFactor;
    public float playerSpeedMulti;
    public float enemySpeedMulti;
    public float DMGFactor;
    public float fireRate;
    public float sizeMulti;
    public float fireDMG;
    public float bulletSizeMulti;
    public int health;
    public float invincibilityTime;
    public float bulletSpeed;
    public TextMeshProUGUI coinText;
    public static gameFactors instance;

    
    public int coins;
    // Start is called before the first frame update
    void Start()
    {
        difficultyFactor = SaveSystem.GetFloat("difficultyFactor");
        playerSpeedMulti = SaveSystem.GetFloat("playerSpeedMulti");
        enemySpeedMulti = SaveSystem.GetFloat("enemySpeedMulti");
        DMGFactor = SaveSystem.GetFloat("DMGFactor");
        fireRate = SaveSystem.GetFloat("fireRate");
        sizeMulti = SaveSystem.GetFloat("sizeMulti");
        health = SaveSystem.GetInt("HP");
        bulletSizeMulti = SaveSystem.GetFloat("bulletSizeMulti");
        bulletSpeed = SaveSystem.GetFloat("bulletSpeedMulti");
        invincibilityTime = SaveSystem.GetFloat("invincibilityTime");

        DontDestroyOnLoad(gameObject);

        SaveSystem.SetFloat("difficultyFactor", difficultyFactor);
        SaveSystem.SetFloat("playerSpeedMulti", playerSpeedMulti);
        SaveSystem.SetFloat("enemySpeedMulti", enemySpeedMulti);
        SaveSystem.SetFloat("DMGFactor", DMGFactor);
        SaveSystem.SetFloat("fireRate", fireRate);
        SaveSystem.SetFloat("sizeMulti", sizeMulti);
        SaveSystem.SetFloat("fireDMG", fireDMG);
        SaveSystem.SetFloat("HP", health);

        if(difficultyFactor == 0f){
            SaveSystem.SetFloat("difficultyFactor", 1f);
            difficultyFactor = SaveSystem.GetFloat("difficultyFactor");
        }
        if(playerSpeedMulti == 0f){
            SaveSystem.SetFloat("playerSpeedMulti", 1f);
            playerSpeedMulti = SaveSystem.GetFloat("playerSpeedMulti");
        }
        if(enemySpeedMulti == 0f){
            SaveSystem.SetFloat("enemySpeedMulti", 1f);
            enemySpeedMulti = SaveSystem.GetFloat("enemySpeedMulti");
        }
        if(DMGFactor == 0f){
            SaveSystem.SetFloat("DMGMulti", 0.75f);
            DMGFactor = SaveSystem.GetFloat("DMGMulti");
        }
        if(fireRate == 0f){
            SaveSystem.SetFloat("fireRate", 1f);
           fireRate = SaveSystem.GetFloat("fireRate");
        }
        if(sizeMulti == 0f){
            SaveSystem.SetFloat("sizeMulti", 1f);
            sizeMulti = SaveSystem.GetFloat("sizeMulti");
        }
        if (bulletSizeMulti == 0f)
        {
            SaveSystem.SetFloat("bulletSizeMulti", 1f);
            bulletSizeMulti = SaveSystem.GetFloat("bulletSizeMulti");
        }
        if (bulletSpeed == 0f)
        {
            SaveSystem.SetFloat("bulletSpeedMulti", 30f);
            bulletSpeed = SaveSystem.GetFloat("bulletSpeedMulti");
        }
        if (health < 2){
            SaveSystem.SetInt("HP", 2);
            health = SaveSystem.GetInt("HP");
        }
        if (invincibilityTime < 2)
        {
            SaveSystem.SetFloat("invincibilityTime", 2);
            invincibilityTime = SaveSystem.GetFloat("invincibilityTime");
        }
    }

    // Update is called once per frame
    void Update()
    {
        coins = SaveSystem.GetInt("Coins");
        coinText.text = coins.ToString();
    }

}
