using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 1;
    private Rigidbody2D rig;
    private float inputHorizontal;
    private float inputVertical;
    public float distance;
    public LayerMask ladder;
    bool isClimbing;
    public GameObject player;
    public float lasty;
    private bool deathtimer;
    private float timeRemaining = 7;
    public GameObject Enemy;
    public EnemyManager enemymng;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        lasty = transform.position.y;
        deathtimer = false;
    }
    // Update is called once per frame
    void Update()
    {
        //sets deathtimer to destroy the enemy while it is trapped
        if (deathtimer == true)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
               Destroy(gameObject);
               enemymng.SpawnNewEnemy();
            }
        }
    }
    void FixedUpdate()
    {
        if (lasty == gameObject.transform.position.y)
        {
            rig.gravityScale = 5;
            int horizontalDirection = player.transform.position.x < gameObject.transform.position.x ? -1 : 1;
            if (player.transform.position.y != gameObject.transform.position.y)
            {
                float minimumdistancetoleftLadder = 0;
                float minimumdistancetorightLadder = 0;
                RaycastHit2D hitleft = Physics2D.Raycast(transform.position, Vector2.left, 200, ladder);
                RaycastHit2D hitright = Physics2D.Raycast(transform.position, Vector2.right, 200, ladder);
                if (hitleft != null && horizontalDirection == -1)
                {
                    rig.velocity = new Vector2(moveSpeed * horizontalDirection, 0);
                }
                else if (hitright != null && horizontalDirection == 1)
                {
                    rig.velocity = new Vector2(moveSpeed * horizontalDirection, 0);
                }
                else
                {
                    if (hitleft != null)
                    {
                        minimumdistancetoleftLadder = Math.Abs(transform.position.x - hitleft.point.x);
                    }
                    if (hitright != null)
                    {
                        minimumdistancetorightLadder = Math.Abs(transform.position.x - hitright.point.x);
                    }
                    if (minimumdistancetoleftLadder > minimumdistancetorightLadder)
                    {
                        rig.velocity = new Vector2(-moveSpeed, 0);
                    }
                    else
                    {
                        rig.velocity = new Vector2(moveSpeed, 0);
                    }
                }
            }
            else
            {
                rig.velocity = new Vector2(moveSpeed * horizontalDirection, 0);
            }

        }
        lasty = transform.position.y;



        //  }
    }
    //if the enemy collides with constrain which is under the bricks it gets frozen
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Constrain"))
        {
            rig.constraints = RigidbodyConstraints2D.FreezeAll;
            deathtimer = true;
            //Destroy(gameObject);         
        }
        //if(col.gameObject.CompareTag("Brick"))
        //{
        //    if(col.transform.position == gameObject.transform.position)
        //    {
        //        Destroy(gameObject);
        //    }
        //}

    }

}



