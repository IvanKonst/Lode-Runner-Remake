using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_level2 : MonoBehaviour
{
    public Transform ladder;
    public Text livesText;
    public static int lives = 3;
    public static int coins = 0;
    public GameObject[] Objs;
    // Start is called before the first frame update
    // Update is called once per frame
    void Start()
    {
        Time.timeScale = 0;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1;
        }

        livesText.text = "Lives: " + GameManager.lives.ToString();
        if (GameManager.coins == 4)
        {
            Instantiate(ladder, new Vector2(2f, 4.00f), Quaternion.identity);
        }

    }
    public void ChangeColorBlue()
    {
        Objs = GameObject.FindGameObjectsWithTag("Brick");
        foreach (GameObject go in Objs)
        {
            go.GetComponent<Renderer>().material.color = Color.blue;
        }
    }
    public void ChangeColorRed()
    {
        Objs = GameObject.FindGameObjectsWithTag("Brick");
        foreach (GameObject go in Objs)
        {
            go.GetComponent<Renderer>().material.color = Color.red;
        }
    }
    public void ChangeColorGreen()
    {
        Objs = GameObject.FindGameObjectsWithTag("Brick");
        foreach (GameObject go in Objs)
        {
            go.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
