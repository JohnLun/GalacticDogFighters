using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Gun : MonoBehaviour
{
    public Transform shotPos;
    public GameObject bulletPrefab;
    public int numBullets;
    public float spread, bulletSpeed;
    public Transform p1;
   public void Shoot()
    {
        for (int i = 0; i < numBullets; i++)
        {
            GameObject b = Instantiate(bulletPrefab, p1.position, p1.rotation);
            Rigidbody2D rigidBody = b.GetComponent<Rigidbody2D>();
            Vector2 dir = p1.rotation * Vector2.up;
            Vector2 pdir = Vector2.Perpendicular(dir) * Random.Range(0, spread);
            rigidBody.velocity = (dir * pdir) * bulletSpeed;
            Debug.Log(rigidBody.velocity);
        }
    }
}
