using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    // Connect movement Script for reading input
    Movement Movement;

    // Connect the camera
    public float FarDistance;

    public float Offset;

    public float lerp;

    private GameObject PLAYER;
    private GameObject MainCamera;

    private Camera CamControls;

    private float CurrentTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Load Movement Script to fetch input data
        Movement = FindObjectOfType<Movement>();
        Debug.Log(Movement + " Script Loaded in " + this.GetComponent<MonoBehaviour>());

        // Load Main Camera
        MainCamera = GameObject.Find("Main Camera");
        PLAYER = GameObject.Find("Player Body");
        CamControls = Camera.main.GetComponentInChildren<Camera>();

       
    }

    // Update is called once per frame
    void Update()
    {
        //Read player / Camera Pos
    float x = PLAYER.transform.position.x;
    float y = PLAYER.transform.position.y;
    float z = MainCamera.transform.position.z;
        
    float xCam = MainCamera.transform.position.x;

                   
        if (Movement.MoveDirection.x < 0)
        // If player is moving left
        {
            CameraLeft();
            CamNormalSize();
            ResTime();
        }

        if (Movement.MoveDirection.x > 0)
        // If player is moving right
        {
            CameraRight();
            CamNormalSize();
            ResTime();
        }

        if (Movement.MoveDirection.x == 0 && Movement.MoveDirection.y != 0)
        {
            CameraNeutral();
            CamNormalSize();
            ResTime();
            // Debug.Log("Movimiento vertical detected niuniuniuwrnofiwnroafienw");
        }

        if (Movement.MoveDirection.x == 0 && Movement.MoveDirection.y == 0)
        {
            // Debug.Log("ZOOMOUT");
            ZoomOut();
        }

        

        void CameraLeft()
        {
            //Debug.Log("MOVE IZQUIERDA");
            Vector3 TargetCamPos = new Vector3(x - Offset, y, z);
            MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, TargetCamPos, lerp * Time.deltaTime);
            // Debug.Log("targetpos = " + TargetCamPos);
        }

        void CameraRight()
        {
            //Debug.Log("MOVE DERECHA");
            Vector3 TargetCamPos = new Vector3(x + Offset, y, z);
            MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, TargetCamPos, lerp * Time.deltaTime);
            // Debug.Log("targetpos = " + TargetCamPos);

        }

        void ZoomOut()
        {
            
            if (CurrentTime < 10f )
            {
                CurrentTime += Time.deltaTime;

                float t = CurrentTime / 10f;

                t = Mathf.Pow(t, 1.2f);

                // Camera Recenters
                Vector3 TargetCamPos = new Vector3(x, y, z);
                MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, TargetCamPos, t);
                
                // Lerp Zoom Out
                CamControls.orthographicSize = Mathf.Lerp(CamControls.orthographicSize, FarDistance, t);
                
                // Debug.Log("Current Time = " + CurrentTime);

            }          
        }

        void ResTime()
            // Resetear la vvariable de tiempo para el zoom out~
        {
            CurrentTime = 0f;
        }

        void CamNormalSize()
        {
        // volver camera normal size
        CamControls.orthographicSize = Mathf.Lerp(CamControls.orthographicSize, 5f, lerp * Time.deltaTime);
        }


        void CameraNeutral()
        {
            Vector3 TargetCamPos = new Vector3(xCam , y, z);
            MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, TargetCamPos, lerp * Time.deltaTime);
        }
    
    }

}
