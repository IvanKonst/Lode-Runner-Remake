using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    //reference to CoinsSoundManger;
   public  CoinsSoundManager coinsSoundMng;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //if the player collides with the coin, sound is being played, and 1 is added to the coins variable;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if( collision.gameObject.CompareTag("Player"))
        {
            GameManager.coins++;
            coinsSoundMng.OnCoinsPickUp();
            Destroy(gameObject);     
            
        }
    }
}
