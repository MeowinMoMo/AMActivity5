using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 20f;
    private float gravy = 9.8f;
    Vector3 direction;
    private GameObject EnemyPrefab;

    private void Start()
    {

    }

    void Update()
    {
        
        if (this == null)
        {
            return;
        }
        transform.Translate(direction * bulletSpeed * Time.deltaTime);
        Destroy(gameObject, 5f);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            float distance = (transform.position - enemy.transform.position).magnitude;
            if (distance <= .7f)
            {
                Destroy(gameObject);
                EnemyHP eneHP = enemy.GetComponent<EnemyHP>();
                eneHP.TakeDamage();
            }
        }
    }


    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }


}   
