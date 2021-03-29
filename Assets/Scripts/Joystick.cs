using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;
    private bool touchStart = false;
    private Vector2 firstpoint;
    private Vector2 secondpoint;
    public Transform innercircle;
    public Transform outtercircle;

    void Update()
    {
        //on screen touch creates virtual joystick to let the player control the character
        if (Input.GetMouseButtonDown(0))
        {
            firstpoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            innercircle.transform.position = firstpoint;
            outtercircle.transform.position = firstpoint;
            innercircle.GetComponent<SpriteRenderer>().enabled = true;
            outtercircle.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            secondpoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            touchStart = false;
        }
    }
    private void FixedUpdate()
    {
        if (touchStart)
        {
            Vector2 offset = secondpoint - firstpoint;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            moveCharacter(direction );

            innercircle.transform.position = new Vector2(firstpoint.x + direction.x, firstpoint.y + direction.y);
        }
        else
        {
            innercircle.GetComponent<SpriteRenderer>().enabled = false;
            outtercircle.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    //function to move the character in the following direction
    void moveCharacter(Vector2 direction)
    {
        player.Translate(direction * speed * Time.deltaTime);
    }
}
