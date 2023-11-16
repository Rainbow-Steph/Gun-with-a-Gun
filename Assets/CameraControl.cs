using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    // Connect movement Script for reading input
    Movement Movement;

    // Connect the camera
    public GameObject Camera;
    public GameObject PLAYER;

    public float Offset;

    private GameObject MainCamera; 


    // Start is called before the first frame update
    void Start()
    {
        // Load Movement Script to fetch input data
        Movement = FindObjectOfType<Movement>();
        Debug.Log(Movement + " Script Loaded in " + this.GetComponent<MonoBehaviour>());

        // Load Main Camera
        MainCamera = GameObject.Find("Main Camera");
        PLAYER = GameObject.Find("Player Body");

    }

    // Update is called once per frame
    void Update()
    {
    float x = PLAYER.transform.position.x;
    float y = PLAYER.transform.position.x;
    float z = MainCamera.transform.position.z;

        
        
        //Read Camera Pos
        Vector3 CameraPos = MainCamera.transform.position;
        Debug.Log("campos = " + CameraPos);

        if (Movement.MoveDirection.x == -1)
        // If player is moving left
        {
            Debug.Log("MOVE IZQUIERDA");
            Vector3 TargetCamPos = new Vector3 (x - Offset, y, z);
            CameraPos = Vector3.Lerp(CameraPos, TargetCamPos, 10 * Time.deltaTime); //ESTO NO FUNCA
            Debug.Log("targetpos = " + TargetCamPos);
        }

     if (Movement.MoveDirection.x == 1)
        // If player is moving right
        {
            Debug.Log("MOVE DERECHA");
            Vector3 TargetCamPos = new Vector3 (x + Offset, y, z);
            CameraPos = new Vector3(20, 20, 20); //ESTO NO FUNCA
            Debug.Log("targetpos = " + TargetCamPos);
        }
         
    }
}
