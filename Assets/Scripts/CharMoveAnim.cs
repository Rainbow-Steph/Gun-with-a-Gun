using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMoveAnim : MonoBehaviour
{
    

    Movement Movement;
    
    // Must Connect Animator!~ 
    public Animator CharAnimator;

    // Start is called before the first frame update
    void Start()
        // Gets inputs from the Movement/Input scripts~
    {
        Movement = FindObjectOfType<Movement>();
        Debug.Log(Movement + " Script Loaded in " + this.GetComponent<MonoBehaviour>());
    }

    // Update is called once per frame
    void Update()
    {
        FeedAnimator();
        FlipAnim();
    }

        void FeedAnimator()
        // setting params for animator tree
        {
            CharAnimator.SetFloat("X", Movement.MoveDirection.x);
            CharAnimator.SetFloat("Y", Movement.MoveDirection.y);
        }

        void FlipAnim()
        // Flip anime when looking left ~
        {
            if (Movement.MoveDirection.x < 0)
            {
                //mirando izq
                transform.localScale = new Vector2(-1f, 1f);
            }

            else if (Movement.MoveDirection.x > 0)
            {
                // mirando der
                transform.localScale = new Vector2(1f, 1f);
            }
        }


    
}
