using Menu;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsSettings : MonoBehaviour
{
    public TMP_Text text;

    public int currentGraphics;
    public Slider graphicsSlider;
    // Start is called before the first frame update
    void Start()
    {
        LoadPlayerPrefs();
    }

    public void LoadPlayerPrefs()
    {
        currentGraphics = PlayerPrefs.GetInt("Quality", 0);


        graphicsSlider.value = currentGraphics;


        QualitySettings.SetQualityLevel(currentGraphics);

        text.text = currentGraphics.ToString();

    }

    public void GraphicsSlider(Slider slider)
    {
        currentGraphics = (int)slider.value;
        QualitySettings.SetQualityLevel(currentGraphics);
        PlayerPrefs.SetInt("Quality", currentGraphics);

        text.text = currentGraphics.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
