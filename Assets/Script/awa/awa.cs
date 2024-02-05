using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class awa : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            FireBullet();
        }
    }

    void FireBullet()
    {
        // Instantiate a new bullet at the firePoint position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Get the bullet's transform
        Transform bulletTransform = bullet.transform;

        // Move the bullet in the forward direction
        bulletTransform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }

}
