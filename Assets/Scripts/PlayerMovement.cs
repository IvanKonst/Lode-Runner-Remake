using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //float variable for the movement speed of the character
    public float moveSpeed = 5;
    //reference to the rigidbody of the character
    private Rigidbody2D rig;
    //float variable for the horizontal movement
    private float inputHorizontal;
    //float variable for the vertical movement
    private float inputVertical;
    //boolean variable for climbing
    bool isClimbing;
    //boolean variable if the player is on rope
    bool onRope;
     void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
     void FixedUpdate()
    {

       // rig.velocity = new Vector2(inputHorizontal * moveSpeed, rig.velocity.y);
        if(rig.velocity == null)
        {
        }

        if (isClimbing == true)
        {
            rig.gravityScale = 0;
            rig.velocity = new Vector2(rig.velocity.x, inputVertical * moveSpeed);
        }
        if(isClimbing == false)
        {
            rig.gravityScale = 5;
        }
        if (onRope == true)
        {
            rig.gravityScale = 0;
            rig.velocity = new Vector2(inputHorizontal *moveSpeed , rig.velocity.y);
        } 
        if(onRope == false)
        {
            rig.gravityScale = 5;
        }
        
    }
    //if the player collides with ladder, gravity is being set to 0 while he is on the ladder and the player is able to move vertically
    // if the player collides with rope, gravity is being set to 0 and the player is able to move horizontally
    void OnTriggerEnter2D(Collider2D col)
    {   
        if(col.gameObject.CompareTag("Ladder"))
        {
            rig.gravityScale = 0;
            isClimbing = true;
        }
        else rig.gravityScale = 5;
        if (col.gameObject.CompareTag("Rope"))
        {
            rig.gravityScale = 0;
            onRope = true;
        }
        
    }
    //if the player is not colliding with ladder anymore, isClimbing is set to false
    //if the player is not colliding with rope anymore, onRope is set to false
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Ladder"))
        {
            isClimbing = false;
        }
        if (col.gameObject.CompareTag("Rope"))
        {
           
            onRope = false;
        }
    }
    //if the player collides with Enemy they lose 1 life and the scene is reloaded
    //if the player collides with EndOfTheLevel, next level scene is loaded
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.lives--;
            SceneManager.LoadScene("MainScene");

            if (GameManager.lives == 0)
            {
                SceneManager.LoadScene("RetryScreen");
                GameManager.lives = 3;
                GameManager.coins = 0;
            }

        }
        if (collision.gameObject.CompareTag("Enemy2"))
        {
            GameManager.lives--;
            SceneManager.LoadScene("Level2");

            if (GameManager.lives == 0)
            {
                SceneManager.LoadScene("RetryScreen");
                GameManager.lives = 3;
                GameManager.coins = 0;
            }

        }
        if (collision.gameObject.CompareTag("EndOfTheLevel"))
        {
            SceneManager.LoadScene("Level2");
            GameManager.coins = 0;
        }
        if (collision.gameObject.CompareTag("EndOfTheLevel2"))
        {
            SceneManager.LoadScene("YouWinScreen");
            GameManager.coins = 0;
        }
    }
}

