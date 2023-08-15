using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageProgressBar : MonoBehaviour
{
    public float value;
    public float minValue;
    public float maxValue;

    public Image fillImage;
    public Image maskImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnValidate()
    {


        fillImage.fillAmount = ((value + minValue) / maxValue);
        maskImage.fillAmount = ((value + minValue) / maxValue);
    }
    // Update is called once per frame
    void Update()
    {
        fillImage.fillAmount = ((value + minValue) / maxValue);
        maskImage.fillAmount = ((value + minValue) / maxValue);
    }
}
