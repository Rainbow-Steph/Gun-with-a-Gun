using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed; 
    public Rigidbody2D Body;

    private Vector2 moveDirection;

    // these not cleaned =>
    public Animator animator;
    public Rigidbody2D GUN;
    public SpriteRenderer GunnySprite;

    public GameObject firepoint;

    public GameObject CamControllerFocus;
    public Rigidbody2D CamController;
    public Camera CAM;

    private Vector2 mousePos;
    private GameObject GUNny;
    private Vector2 AimDirection;

    // these not cleaned <=





    
    

       // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }
    private void FixedUpdate()
    {
        // REFACTORED Move();
        /// physics calculations
        /// 
    }


    void ProcessInputs()
    {
        // processing inputs
        // REFACTORED  float moveX = Input.GetAxisRaw("Horizontal");
        // REFACTORED float moveY = Input.GetAxisRaw("Vertical");

        // REFACTORED moveDirection = new Vector2(moveX, moveY).normalized;
        // aim direction



        // AIM~~~~~~~~~~~~~~~~~~~~~~
       // REFACTORED  AimDirection = mousePos - GUN.position;

        // getting pointer from pixel location to usable inputs
        // REFACTORED  mousePos = CAM.ScreenToWorldPoint(Input.mousePosition);



        // ANIMATORRRRRRRRRRRRRRR 
        // setting params for animator tree
        // REFACTORED animator.SetFloat("X", moveX);
        // REFACTORED animator.SetFloat("Y", moveY);


        // CAMERAAAAAAAAAAAAAAAA
        // setting up camera lerp~
        float x = transform.position.x;
        float y = transform.position.y;
        float z = CAM.transform.position.z;
        Vector3 Vec1 = CamControllerFocus.transform.position;



        //ANIM V2 
        // Mirroring anim
  //    if (moveX < 0)
        {
            //mirando izq
            // REFACTORED  transform.localScale = new Vector2(-1f, 1f);
            // REFACTORED firepoint.transform.localRotation = new Quaternion(0, 0, 180, 0);


            // Camera Lerp

            Vector3 cam = CamControllerFocus.transform.position = new Vector3(x - 2, y, z);
            CamControllerFocus.transform.position = Vector3.Lerp(Vec1, cam, 10*Time.deltaTime);


            // old way >.< CamControllerFocus.transform.SetPositionAndRotation(Vector3.Lerp(new Vector3(transform.position.x - 2, transform.position.y, CAM.transform.position.z), new Vector3(transform.position.x + 2, transform.position.y, CAM.transform.position.z), Time.deltaTime), Quaternion.identity);
        }
//      else if (moveX > 0)
        {
            // mirando der
            // REFACTORED    transform.localScale = new Vector2(1f, 1f);
            // REFACTORED firepoint.transform.localRotation = new Quaternion(0, 0, 0, 0);

            // lerp
            Vector3 cam = CamControllerFocus.transform.position = new Vector3(x + 2, y, z);
            CamControllerFocus.transform.position = Vector3.Lerp(Vec1, cam, 10 * Time.deltaTime);
            // old way >.< CamControllerFocus.transform.SetPositionAndRotation(Vector3.Lerp(new Vector3(transform.position.x + 2, transform.position.y, CAM.transform.position.z), new Vector3(transform.position.x - 2, transform.position.y, CAM.transform.position.z), Time.deltaTime), Quaternion.identity);
        }




        // convert to an usable angle
        // REFACTORED float angle = Mathf.Atan2(AimDirection.y, AimDirection.x) * Mathf.Rad2Deg;

        // REFACTORED GUN.rotation = angle;


        // Mirroring gun
        // REFACTORED 
        // REFACTORED GUNny = GameObject.Find("GUNGUNGUN");
        // REFACTORED if (angle <= 90 && angle >= -90)
        // REFACTORED { GunnySprite.flipY = false;        }
        // REFACTORED else if (angle > 90 | angle < -90)
        // REFACTORED { GunnySprite.flipY = true;        }


        // Gun behind char

        // REFACTORED GUNny = GameObject.Find("GUNGUNGUN");
        // REFACTORED if (angle  >= 0)
        // REFACTORED {            GUNny.transform.localPosition = new Vector3(GUNny.transform.localPosition.x, GUNny.transform.localPosition.y, 5);  
    }
    // REFACTORED else if (angle < 0)
    // REFACTORED {            GUNny.transform.localPosition = new Vector3(GUNny.transform.localPosition.x, GUNny.transform.localPosition.y, -5);
    //GUNny.transform.localScale = new Vector2(-1f, 1f);
    //GunnySprite.flipY = true;
}



// REFACTORED void Move()

    // already refactored Body.velocity = new Vector2(moveDirection.x * MoveSpeed, moveDirection.y * MoveSpeed);
    // REFACTORED GUN.position = new Vector2(Body.position.x, Body.position.y - 0.2f);
    





// NOT REF YET CamController.velocity = new Vector2(moveDirection.x * MoveSpeed, moveDirection.y * MoveSpeed);

   

