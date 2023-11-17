using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public EnemyLogic EnemyState;
    public GameObject HitEffect;
    
    public Collision2D Impacted;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Impacted = collision;
        
        if (collision.collider.CompareTag("Enemy"))
        {
            KillIt();
            Impact();
        }

        else 
        {
            Impact(); 
        }

            
    }

    void Impact()
        // Impacts the target 
    {
        // Run Impact Anim
        GameObject effect = Instantiate(HitEffect, transform.position, Quaternion.identity);

        // Debugs target hit
        Debug.Log("Hit " + Impacted.collider.gameObject.name + " with " + gameObject.name);

        // Removes Bullet
        Destroy(effect, 5f);
        Destroy(gameObject);
    }
    
    void KillIt()
    // Kills the enemy target
    {
        // Enables trigger for death anim 
        Animator Death = Impacted.collider.gameObject.GetComponent<Animator>();
        Death.SetBool("Dead", true);

        // Sends object to 'dead' background layer
        Impacted.collider.gameObject.layer = 3;

        // Changes alive state to death in enemy prefab logic
        EnemyState = Impacted.collider.gameObject.GetComponentInChildren<EnemyLogic>();
        
        EnemyState.Alive = false;

        // resets enemy speed so it doesn't ragdoll away
        Impacted.collider.attachedRigidbody.velocity = new Vector2(0, 0);

    }


}
