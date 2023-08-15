using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SliderMask : MonoBehaviour
{
    public Slider slider;
    public Slider maskedSlider;

    // Start is called before the first frame update
    void Start()
    {
        //if (maskedSlider == null)
        //    DupeSlider();
    }

    public void OnValidate()
    {
    //    if (maskedSlider == null)
    //        DupeSlider();


        maskedSlider.value = slider.value;

    }

    public void DupeSlider()
    {
        //slider = GetComponent<Slider>();
        //maskedSlider = GameObject.Instantiate(gameObject, gameObject.transform).GetComponent<Slider>();
        //maskedSlider.fillRect.GetComponent<Image>().material = null;
        //maskedSlider.name = slider.name+"_Color";

        //UnityEditor.EditorApplication.delayCall += () =>
        //{
        //    DestroyImmediate(maskedSlider.GetComponent<SliderMask>());
        //};

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        maskedSlider.value = slider.value;
    }

    private void OnDisable()
    {
        Debug.Log("MyComponent was disabled or removed.");

       // Destroy(maskedSlider);
    }
}
