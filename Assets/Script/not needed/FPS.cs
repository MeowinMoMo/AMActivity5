using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject projectilePrefab;
    PlayerCam playerCamera;
    public float fireRate = 1f;
    public float enemySpawnRate = 1f;
    public float enemyMinDistance = 5f;
    public float enemyMaxDistance = 20f;
    public float enemySpeed = 1f;
    public float projectileSpeed = 100f;
    private float nextFireTime;
    private float nextEnemySpawnTime;
    private List<GameObject> enemies;
    private int kills;

    void Start()
    {
        enemies = new List<GameObject>();
        nextFireTime = Time.deltaTime;
        nextEnemySpawnTime = Time.deltaTime;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.deltaTime >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.deltaTime + 1f / fireRate;
        }

        if (Time.deltaTime >= nextEnemySpawnTime)
        {
            SpawnEnemy();
            nextEnemySpawnTime = Time.deltaTime + 1f / enemySpawnRate;
        }

        if (enemies.Count > 0)
        {
            foreach (GameObject enemy in enemies)
            {
                if (enemy != null)
                {
                    enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, transform.position, enemySpeed * Time.deltaTime);
                }
                else
                {
                    enemies.Remove(enemy);
                }
            }
        }
    }

    void Shoot()
    {
        Vector3 rayOrigin = playerCamera.transform.transform.position;
        Vector3 rayDirection = playerCamera.transform.transform.forward;
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, rayDirection, out hit))
        {
            GameObject enemy = hit.transform.gameObject;

            if (enemy.CompareTag("Enemy"))
            {
                Destroy(enemy);
                kills++;

                if (kills >= 10)
                {
                    // Activate auto aim power up
                }
            }
        }

        GameObject projectile = Instantiate(projectilePrefab, rayOrigin, Quaternion.identity);
        projectile.GetComponent<Rigidbody>().velocity = rayDirection * projectileSpeed;
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-enemyMaxDistance, enemyMaxDistance), 0, Random.Range(-enemyMaxDistance, enemyMaxDistance));

        if (Physics.Raycast(spawnPosition, Vector3.down, out RaycastHit hit))
        {
            if (hit.distance > enemyMinDistance)
            {
                GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                enemies.Add(enemy);
            }
        }
    }
}
