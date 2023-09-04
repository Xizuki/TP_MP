using Menu;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;



namespace menu
{
    public class VolumeSlider : MonoBehaviour
    {

        public DictionaryVolumeSettings dictionary;

        [SerializeField]
        private Slider volumeSlider;

        [SerializeField]
        private TextMeshProUGUI text;

        [SerializeField]
        private SoundControl soundControl;

        [SerializeField]
        private float volumeMultiplier = 0.1f;

        [SerializeField]
        private string setting = "Volume";


        private void Awake()
        {
            dictionary = FindObjectOfType<DictionaryVolumeSettings>();

            soundControl = FindObjectOfType<SoundControl>();
        }


        private void Start()
        {
            volumeSlider.value = dictionary.SoundSettings[setting];
            
        }

        private void Update()
        {
            
        }

 



        public void AdjustDictionaryWithSliderValue() //Used by the OnValueChanged attached to the slider
        {

          
            dictionary.SoundSettings[setting] = volumeSlider.value; // Adjust dictionary value with sound slider value

                
            foreach (KeyValuePair<string, float> pair in dictionary.SoundSettings)// Print out the sound setting value
            {
                Debug.Log("Sound settings: " + pair.Key + ": " + pair.Value); 
            }

            TextUpdate(volumeMultiplier);  

            dictionary.WriteToPlayerPrefsSound();

            soundControl.AdjustAll();
        }

        void TextUpdate(float multiplier)
        {
            

            text.text = (dictionary.SoundSettings[setting]* multiplier).ToString();  

           
        }
    }
}
