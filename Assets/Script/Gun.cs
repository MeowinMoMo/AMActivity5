using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private GameObject Barrel;
    public bool isPowerUpON;
    public bool isAutoTarget;
    public bool isFiring;
    public float Timer;


    private void Start()
    {
        isPowerUpON = false;
        isAutoTarget = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
        if (Input.GetKeyDown(KeyCode.F) && !isPowerUpON)
        {
            StartCoroutine(CheckForTimer());
        }
        if (isAutoTarget && GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            transform.LookAt(GameObject.FindGameObjectWithTag("Enemy").transform.position);
            if (!isFiring)
            {
                StartCoroutine(TimeFire());
            }
        }
        if (GameObject.FindGameObjectWithTag("Enemy") == null && isFiring)
        {
            isFiring = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 25f);
    }
    public void Fire()
    {
        GameObject BulletClone = Instantiate(BulletPrefab, Barrel.transform.position, Quaternion.identity);
        Bullet bullet = BulletClone.GetComponent<Bullet>();
        bullet.SetDirection(transform.forward);
    }

    IEnumerator CheckForTimer() 
    {
        
        isPowerUpON = true;
        isAutoTarget = true;

        yield return new WaitForSeconds(10f); 
     
        isPowerUpON = false;
        isAutoTarget = false;
        Debug.Log("PowerUp off");
    }

    IEnumerator TimeFire() 
    {
        bool canfire = true;
        Fire();
        isFiring = true;
        yield return new WaitForSeconds(.5f);
        canfire = false;
        isFiring = false;
    }
}
