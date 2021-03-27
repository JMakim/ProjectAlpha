using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour
{
    public AudioSource bgMusic;
    public float musicVolume = 1;
    // Start is called before the first frame update
    void Start()
    {
        musicVolume = 1;
    }

    // Update is called once per frame
    void Update()
    {
        bgMusic.volume = musicVolume;
    }

    public void changeVolume(float volume)
    {
        musicVolume = volume;
    }
}
