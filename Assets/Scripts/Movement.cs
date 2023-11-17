using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float MoveSpeed;
    
    public GameObject PlayerBody;
    


    public Vector2 MoveDirection;

    
    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    // triggers every fixed frame interval (no weird stuff from pc running at a quintillon fps)
    private void FixedUpdate()
    {
        Move();
    }


    
    void ProcessInputs()
    // Reads Horizontal+Vertical Inputs (configured in Unity Inputs), updates MoveDirection
    {
        // reading inputs
        float InputX = Input.GetAxisRaw("Horizontal");
        float InputY = Input.GetAxisRaw("Vertical");

        //  MoveDirection returns -1, 0 or 1 for each axis
        MoveDirection = new Vector2(InputX, InputY).normalized;

    }

    void Move()
    // Moves the Character around
    {
        Rigidbody2D PlayerPhysics = PlayerBody.GetComponent<Rigidbody2D>();
        PlayerPhysics.velocity = new Vector2(MoveDirection.x * MoveSpeed, MoveDirection.y * MoveSpeed);
    }

}
