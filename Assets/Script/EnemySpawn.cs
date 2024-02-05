using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] SpawnAreaPoint;
    public GameObject EnemyPrefab;
    int SpawnIndex;

    private void Start()
    {
        InvokeRepeating("SpawnEnemies", 3f, 2.5f);
    }

    public void SpawnEnemies()
    {
        
        SpawnIndex = Random.Range(0, SpawnAreaPoint.Length);
        GameObject spawnChecker =  Instantiate(EnemyPrefab, SpawnAreaPoint[SpawnIndex].transform.position, Quaternion.identity);
        float distance = (spawnChecker.transform.position - GameObject.FindGameObjectWithTag("Player").transform.position).magnitude;

        if (distance <=25)
        {
            Destroy(spawnChecker);
            Debug.Log("Enemy Spawn too close");
        }

    }
}
