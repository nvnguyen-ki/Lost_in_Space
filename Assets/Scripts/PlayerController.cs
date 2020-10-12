using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// inherit from MonoBehavioor
public class PlayerController : MonoBehaviour
{
    float speed = 3.0f;
    float runSpeed = 6.0f;
    private float turnSpeed = 45f;
    private float MouseInput;
    private float VerticalInput;
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    // Start is called before the first frame update
    Animator anim;
    int isWalking;
    int isRunning;
    public float maxHealth = 100;
    public float currentHealth;
    public HealthBar healthBar;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        anim = GetComponent<Animator>();
        isWalking = Animator.StringToHash("isWalking");
        isRunning = Animator.StringToHash("isRunning");
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
        // update the vehicle movement
        MouseInput = Input.GetAxis("Mouse X");
        VerticalInput = Input.GetAxis("Vertical");
        bool runShift = Input.GetKey("left shift");
        bool jump = Input.GetKey("space");

        // move foward : moving the z (60 units in a second) based on vertical input
        
        // turn : rotate the car based on horizontal input
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * MouseInput);
        if (VerticalInput > 0)
        {
            transform.Translate(Vector3.forward * (Time.deltaTime * speed * VerticalInput));
            anim.SetBool(isWalking, true);
            anim.SetFloat("Speed", 1.0f);
            takeDamage(0.01f);
        } 
        else if (VerticalInput < 0)
        {
            transform.Translate(Vector3.forward * (Time.deltaTime * speed * VerticalInput));
            anim.SetBool(isWalking, true);
            anim.SetFloat("Speed", -1.0f);
            
        } else
        {
            anim.SetBool(isWalking, false);
        }

        if (VerticalInput > 0 && runShift)
        {
            anim.SetBool(isRunning, true);
            transform.Translate(Vector3.forward * (Time.deltaTime * runSpeed * VerticalInput));
        } else
        {
            transform.Translate(Vector3.forward * (Time.deltaTime * speed * VerticalInput));
            anim.SetBool(isRunning, false);
        }


        /*if (jump && isOnGround) {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            anim.SetBool(isJumping, true);
        } else if (!jump)
        {
            anim.SetBool(isJumping, false);
        }
        */
    

}
    void takeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
    
}
