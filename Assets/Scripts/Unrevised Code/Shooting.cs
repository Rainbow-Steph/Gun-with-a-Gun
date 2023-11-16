using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject BulletPrefab;

    public float bulletForce = 20f;

    public AudioSource BANG;


   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // esto quizas es util InvokeRepeating("Shoot", 1, 2);
            Shoot();
        }
    }

    void Shoot()
    {

        GameObject bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(FirePoint.right * bulletForce, ForceMode2D.Impulse);

        BANG.Play ();
    }
}
