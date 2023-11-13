using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    //Camera gets mouse relative pos
    public Camera MainCamera;

    //Object to move with Rigidbody2D
    public GameObject PlayerGun;

    Vector2 AimDirection;
    private Rigidbody2D GunBody;
    private SpriteRenderer GunSprite;

    private GameObject PlayerBody;
    private GameObject FirePoint;
    // Start is called before the first frame update
    void Start()
    {
        // Get rigigbody component from GameObject
        GunBody = PlayerGun.GetComponent<Rigidbody2D>();
        GunSprite = PlayerGun.GetComponentInChildren<SpriteRenderer>();

        FirePoint = GameObject.Find("Gun FirePoint");
        PlayerBody = GameObject.Find("Player Body");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        WeaponFollowsMouse();
        FixToChar();
        FlipWeapon();
        HideWeapon();
    }

    void WeaponFollowsMouse()
    // Make the weapon follow the mouse pointer
    {
        // Vector2 Difference between where mouse is pointing and Logic object pos
        AimDirection = MainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        // Convert Vector to Radius (arc tan)
        float GunAngle = Mathf.Atan2(AimDirection.y, AimDirection.x) * Mathf.Rad2Deg;
        // Apply Movement to Gun GameObject

        GunBody.rotation = GunAngle;


    }

    void FlipWeapon()
    // fix for flipping gun sprite
    {
        if (GunBody.rotation <= 90 && GunBody.rotation >= -90)
        {
            GunSprite.flipY = false;
            // Adjust FirePoint Position
            FirePoint.transform.localPosition = new Vector3(FirePoint.transform.localPosition.x, 0.072f, 0);
        }

        else if (GunBody.rotation > 90 | GunBody.rotation < -90)
        {
            GunSprite.flipY = true;
            // Adjust FirePoint Position
            FirePoint.transform.localPosition = new Vector3(FirePoint.transform.localPosition.x, -0.1f, 0);
        }
    }

    void HideWeapon()
    // Get Weapon Behind Char
    {
        if (GunBody.rotation >= 0)
        {
            PlayerGun.transform.localPosition = new Vector3(PlayerGun.transform.localPosition.x, PlayerGun.transform.localPosition.y, 5);

        }
        else if (GunBody.rotation < 0)
        {
            PlayerGun.transform.localPosition = new Vector3(PlayerGun.transform.localPosition.x, PlayerGun.transform.localPosition.y, -5);
        }
    }

    void FixToChar()
    // fixes weapon to Character
    {
        PlayerGun.transform.position = new Vector3(PlayerBody.transform.localPosition.x, PlayerBody.transform.localPosition.y - 0.15f, PlayerGun.transform.localPosition.z);
    }
}
