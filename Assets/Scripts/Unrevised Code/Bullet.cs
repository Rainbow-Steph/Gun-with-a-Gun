using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public EnemyLogic EnemyState;
    public GameObject HitEffect;
    public GameObject E;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.tag == "Enemy")
        {
            GameObject effect = Instantiate(HitEffect, transform.position, Quaternion.identity);
            Animator Death = collision.collider.gameObject.GetComponent<Animator>();
            Death.SetBool("Dead", true);

            Debug.Log("Killed " + collision.collider.gameObject.name);
            collision.collider.gameObject.layer = 3;

            E = collision.collider.gameObject;
            //Debug.Log(collision.collider.GetComponentInChildren < "Enemy React Zone" >);
            EnemyState = E.GetComponentInChildren<EnemyLogic>();
            EnemyState.Alive = false;
            collision.collider.attachedRigidbody.velocity = new Vector2(0, 0);

            Destroy(effect, 5f);
            Destroy(gameObject);
        
        }

            else {
                    GameObject effect = Instantiate(HitEffect, transform.position, Quaternion.identity);
                    Destroy(effect, 5f);
                    Destroy(gameObject);
            Debug.Log("Hit  " + collision.collider.gameObject.name);
        }

            // quaternion.identity = este objeto no ta rotado
    }


}
