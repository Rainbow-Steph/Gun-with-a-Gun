using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyLogic : MonoBehaviour
{
    public bool Alive;
    public Rigidbody2D Enemy;
    private Vector2 MoveDirection;
    public float EnemySpeed = 5;
    bool WithinRange = false;
    public Animator MonsterAnim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        { 
        Debug.Log("Within Range");
        MonsterAnim.SetBool ("IsMoving",  true);
        WithinRange = true;
    }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Outside Range");
            MonsterAnim.SetBool("IsMoving", false);
            WithinRange = false;
            Enemy.velocity = new Vector2(MoveDirection.x * 0, MoveDirection.y * 0);
        }
    }


    // Update is called once per frame
    void Update()
    {

        
     

    }

    private void FixedUpdate()
    {
        if (WithinRange == true) 
        {
                        Attacking();
        }
    }

   
    void Attacking()
    {
        if (Alive == true)
        {
            MoveDirection = GameObject.Find("Main Character").transform.position - transform.position;
            Enemy.velocity = new Vector2(MoveDirection.x * EnemySpeed, MoveDirection.y * EnemySpeed);

            if (Enemy.velocity.x < 0)
            {
                Enemy.transform.localScale = new Vector2(-1, 1);
            }

            if (Enemy.velocity.x > 0)
            {
                Enemy.transform.localScale = new Vector2(1, 1);
            }
        }
    }
}
