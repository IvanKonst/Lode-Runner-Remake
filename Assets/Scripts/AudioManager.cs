using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    
    public static AudioClip coinsSound, playerDropSound, brickDestroyedSound, enemyDeathSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        
        coinsSound = Resources.Load<AudioClip>("coinsSound");
        playerDropSound = Resources.Load<AudioClip>("PlayerDrop");
        brickDestroyedSound = Resources.Load<AudioClip>("BrickDestroyed");
        enemyDeathSound = Resources.Load<AudioClip>("EnemyDeath");
        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound(string clip)
    {
        switch(clip)    
        {
            case "coins":
                audioSrc.PlayOneShot(coinsSound);
                    break;
            case "playerdrop":
                audioSrc.PlayOneShot(playerDropSound);
                break;
            case "brickdestroyed":
                audioSrc.PlayOneShot(brickDestroyedSound);
                break;
            case "enemydeath":
                audioSrc.PlayOneShot(enemyDeathSound);
                break;
        }
    }

}
