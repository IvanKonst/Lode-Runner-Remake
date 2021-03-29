using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //reference to Enemy
    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //function that spawns new enemy while the first was destroyed
    public void SpawnNewEnemy()
    {
        GameObject newEnemy = Instantiate(Enemy, new Vector2(4, 4), Quaternion.identity);
    }
}
