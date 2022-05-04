using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform[] fireLocations;
    [SerializeField] float bulletSpeed;
    [SerializeField] private float fireDelay;
    [SerializeField] private int numBullets;
    [SerializeField] private bool shootingBarrels;

    private List<GameObject> bullets = new List<GameObject>();
    private GameObject newBullet; 
    private Vector3 bulletVelocity;
    private int curBullet;

    private void Start()
    {
        InitialisePool();
        if (!shootingBarrels)
        {
            InvokeRepeating("FireBullet", 0, fireDelay);
        }
    }

    private void InitialisePool()
    {
        for (int i = 0; i < numBullets; i++)
        {
            newBullet = Instantiate(bulletPrefab);
            newBullet.SetActive(false);
            bullets.Add(newBullet);
        }

        curBullet = 0;
    }

    private void FireBullet()
    {
        if (!gameObject.activeSelf) 
        { 
            CancelInvoke(); 
            return; 
        }

        for (int i = 0; i < fireLocations.Length; i++)
        {
            newBullet = bullets[curBullet];
            newBullet.SetActive(true);
            newBullet.transform.position = fireLocations[i].position;

            bulletVelocity = fireLocations[i].up * bulletSpeed;
            newBullet.GetComponent<Rigidbody2D>().velocity = bulletVelocity;

            curBullet++;
            if (curBullet >= numBullets) curBullet = 0;
        }
    }
}
