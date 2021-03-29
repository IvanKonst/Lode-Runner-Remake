using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSoundManager : MonoBehaviour
{
    //Audioclip for the coins sound
    public AudioClip coins;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = coins;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //function to play the coins sound when one is picked up
    public  void OnCoinsPickUp()
    {
        GetComponent<AudioSource>().Play();
    }
}
