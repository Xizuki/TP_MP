using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject cam;
    public GameObject UI;
    public GameObject selectStage;
    public GameObject options;
    public AudioSource audioSource;
    public GameObject blackBars;
    public GameObject skipBtn;
    public AudioClip clip;
    public AudioClip clipOptions;
    public GameObject loadingTxtObject;
    public TMP_Text loadingTxt;
    public bool camUp;

    string[] lore = {"Shiba is sneaking into the castle to save the princess.","The Shiba is able to jump high with it's Power Crystal!"
            ,"The Shiba is a dog of justice, with the goal of saving the princess!","The Shiba is able to defend itself with it's Mighty Shield."
            ,"The Shiba has squishy cheeks that everyone loves.","Use your focus to charge up your jump to jump higher!","The Stopwatch is able to slow down time for you to get past enemies more easily."
            ,"The Mighty Chicken is strong enough to carry the Shiba. It's the Shiba's loyal sidekick!","To protect the kingdom of Shibaland, the Shiba must reach the top of the castle!"
            ,"The Shield is able to defend the Shiba from incoming attacks."};

    void Start()
    {
        blackBars.SetActive(false);
        cam.SetActive(false);
        camUp = false;
        skipBtn.SetActive(false);
        loadingTxtObject.SetActive(false);
    }
    
    public void CamTwo()
    {
        cam.SetActive(true);
        UI.SetActive(false);
        StartCoroutine(WaitTime());
    }

    public void CamOff()
    {
        cam.SetActive(false);

    }   

    public void SelectStage()
    {
        UI.SetActive(false);
        selectStage.SetActive(true);
    }

    // QUICK CHANGE TO MAKE MENU WORKS
    public void StartStage(string sceneName)
    {
        UI.SetActive(false);
        selectStage.SetActive(true);

        SceneManager.LoadScene(sceneName);
    }

    public void CloseStage()
    {
        UI.SetActive(true);
        selectStage.SetActive(false);
    }

    public void OnClickStart()
    {
        blackBars.SetActive(true);
        skipBtn.SetActive(true);
        selectStage.SetActive(false);
        camUp = true;
        audioSource.PlayOneShot(clip);
        loadingTxtObject.SetActive(true);
        loadingTxt.text = lore[Random.Range(0,lore.Length)];
    }

    public void OnClickOptions()
    {
        audioSource.PlayOneShot(clipOptions);
        UI.SetActive(false);
        options.SetActive(true);
    }

    IEnumerator WaitTime()
    {
        print("Scene Loading");
        yield return new WaitForSeconds(5.75f);
        SceneManager.LoadScene(3);

    }

    IEnumerator SkipIntro()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(3);
    }

    public void SkipIntroMain()
    {
        StartCoroutine(SkipIntro());
    }

    private void Update()
    {
        if (camUp == true)
        {
            CamTwo();
        }
        else if (camUp == false)
        {
            CamOff();
        }
    }
}
