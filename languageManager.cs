using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class languageManager : MonoBehaviour
{
    //0 - English
    //1 - Spanish
    //2 - Italian
    //3 - Russian
    public int lang;
    public upgradeSystem US;

    public string[] NormalReplacementsENG;
    public string[] NormalReplacementsESP;
    public string[] NormalReplacementsITL;
    public string[] NormalReplacementsRUS;
    public Text[] NormalText;

    public string[] TMProReplacementsENG;
    public string[] TMProReplacementsESP;
    public string[] TMProReplacementsITL;
    public string[] TMProReplacementsRUS;
    public TextMeshProUGUI[] TMProText;

    public GameObject langPanel;

    // Start is called before the first frame update
    void Start()
    {
        if( PlayerPrefs.GetString("langdefault", "no") == "no")
        {
            langPanel.SetActive(true);
            PlayerPrefs.SetString("langdefault", "yes");
        }

        Debug.Log("LANGUAGE: " + lang);
        lang = PlayerPrefs.GetInt("language", -1);
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < TMProText.Length; i++)
        {
            if( lang == 0 ) TMProText[i].text = TMProReplacementsENG[i];
            if (lang == 1 ) TMProText[i].text = TMProReplacementsESP[i];
            if (lang == 2 ) TMProText[i].text = TMProReplacementsITL[i];
            if (lang == 3 ) TMProText[i].text = TMProReplacementsRUS[i];
        }

        for (int i = 0; i < NormalText.Length; i++)
        {
            if (lang == 0) NormalText[i].text = NormalReplacementsENG[i];
            if (lang == 1) NormalText[i].text = NormalReplacementsESP[i];
            if (lang == 2) NormalText[i].text = NormalReplacementsITL[i];
            if (lang == 3) NormalText[i].text = NormalReplacementsRUS[i];
        }

    }

    public void SetLand(int newLang)
    {
        lang = newLang;
        PlayerPrefs.SetInt("language", newLang);
    }

    public void PanelOff()
    {
        langPanel.SetActive(false);
        PlayerPrefs.SetString("langdefault", "yes");
    }
}
