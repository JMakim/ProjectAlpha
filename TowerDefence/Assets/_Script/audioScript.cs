using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioScript : MonoBehaviour
{
    // might need to clean up at a later date
    public AudioSource[] audio;
    public AudioSource buttonClick;
    public AudioSource gameOver;
    public AudioSource menuScene;
    public AudioSource bombTurretExplosion;
    public AudioSource bombTurretFiring;
    public AudioSource cannonTurret;

    // Start is called before the first frame update
    void Start()
    {
        menuScene = audio[0];

        
        cannonTurret = audio[3];
        bombTurretFiring = audio[4];
        bombTurretExplosion = audio[5];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void btnClick()
    {
        menuScene.Play();
    }

    public void cannonFire()
    {
        cannonTurret.Play();
    }
}
