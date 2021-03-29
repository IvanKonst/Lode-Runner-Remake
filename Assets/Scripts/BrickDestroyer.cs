using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickDestroyer : MonoBehaviour
{
    // Reference to the player
    public GameObject player;
    // radius for the brick to be destroyed
    private float radius = 1;
    // bool variable for the brick to be respawned
    private bool brickrespawned;
    // timer for the brick to be respawned
    private float timeRemaining;
    // bool variable brick destroyed
    private bool brickdestroyed;
    // Start is called before the first frame update
    void Start()
    {
        brickdestroyed = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if the brick is destroyed, set time for it to respawn
        if (brickdestroyed == true)
        {

            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                //enable the brick collider and sprite renderer
                gameObject.GetComponent<Collider2D>().enabled = true;
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                brickdestroyed = false;
            }

        }
    }
    //function to destroy bricks on touch
    void OnMouseDown()
    {
        //if the brick is between player position - radius and player position + radius, then lets the player to destroy it
        if (gameObject.transform.position.y < player.transform.position.y)
        {
            if (gameObject.transform.position.x > player.transform.position.x - radius &&
                gameObject.transform.position.x < player.transform.position.x + radius)
            {
                BrickControl();
                brickdestroyed = true;
            }
        }
    }
    //function that disables the collider and sprite renderer of the brick and sets timer for it to respawn
    public void BrickControl()
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        timeRemaining = 10;
    }


}
