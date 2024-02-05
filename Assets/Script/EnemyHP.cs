using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int EneHealth = 3;
    int CurrentHP;
    int EneKilled;

    void Start()
    {
        CurrentHP = EneHealth;
    }

    public void TakeDamage()
    {
        Debug.Log("Enemy taken damage");
        EneHealth--;
        CurrentHP = EneHealth;
        if (CurrentHP == 0)
        {
            Destroy(gameObject);
            EneKilled++;
        }
    }


}
