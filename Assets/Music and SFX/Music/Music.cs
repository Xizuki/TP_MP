using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource music;
    public static float volume;
    public float vol;

    private void Start()
    {
        music.ignoreListenerPause = true;
        music.playOnAwake = true;
    }
    // Update is called once per frame
    void Update()
    {
        //volume = vol;
        //vol = volume;
        //music.volume = volume/100;

    }
}
