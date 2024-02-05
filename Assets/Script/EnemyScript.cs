using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {                                         
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, 3 * Time.deltaTime);
    }

}
