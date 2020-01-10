using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public Rigidbody2D rb;
    public Vector2 counterJumpForce;
    public float jumpForce;
    public float speed;

    [Header("Weapon Settings")]
    public Transform weaponPoint;
    public Transform firedShots;
    public GameObject shot;
    public float fireRate;
    public float shotForce;

    [HideInInspector]
    public bool isGrounded = true;
    private bool isJumping = false;
    private bool jumpKeyHeld = false;
    private Vector2 movement;
    private float nextFire;

    private void FixedUpdate() 
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = 0;

        if(isJumping)
        {
            if(!jumpKeyHeld && Vector2.Dot(rb.velocity, Vector2.up) > 0)
            {
                rb.AddForce(counterJumpForce * rb.mass);
            }
        }
    }

    private void Update() 
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpKeyHeld = true;
            if(isGrounded)
            {
                isGrounded = false;
                isJumping = true;
                rb.AddForce(Vector2.up * jumpForce * rb.mass, ForceMode2D.Impulse);
            }
        }
        else if(Input.GetButtonUp("Jump"))
        {
            jumpKeyHeld = false;
        }

        if(Input.GetMouseButton(0))
        {
            if(Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Fire();
            }
        }

        rb.position += movement * speed * Time.deltaTime;
    }

    private void Fire()
    {
        GameObject go = Instantiate(shot, weaponPoint.position, Quaternion.identity, firedShots);
        
        go.GetComponent<Rigidbody2D>().AddForce(FindDirection(weaponPoint.position, Camera.main.ScreenToWorldPoint(Input.mousePosition)) * shotForce, ForceMode2D.Impulse);
    }

    private Vector2 FindDirection(Vector3 self, Vector3 target)
    {
        Vector3 dir = (target - self).normalized;

        return new Vector2(dir.x, dir.y);
    }
}
