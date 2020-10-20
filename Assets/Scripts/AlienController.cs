using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// inherit from MonoBehavioor
public class AlienController : MonoBehaviour
{
    float speed = 3.0f;
    float runSpeed = 6.0f;
    public float mouseSens = 100f;
    private float turnSpeed = 45f;
    private float MouseInput;
    private float verticalMouse;
    private float VerticalInput;
    // Start is called before the first frame update
    Animator anim;
    int isWalking;
    int isRunning;
    public float maxHealth = 100;
    public float currentHealth;
    public HealthBar healthBar;
    public CharacterController cc;
    Vector3 velocity;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;
    public Image key;
    bool isGrounded;
    public Transform playerbody;
    void Start()
    {
        key.enabled = false;
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        isWalking = Animator.StringToHash("isWalking");
        isRunning = Animator.StringToHash("isRunning");
        this.currentHealth = maxHealth;
        this.healthBar.SetMaxHealth(maxHealth);
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // check if grounded through a sphere at the feet
        
        if (!isDead)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
            velocity.y += gravity * Time.deltaTime;
            cc.Move(velocity * Time.deltaTime);
            MouseInput = Input.GetAxis("Mouse X");
            verticalMouse = Input.GetAxis("Mouse Y");
            VerticalInput = Input.GetAxis("Vertical");
            bool runShift = Input.GetKey("left shift");
            Vector3 move;
            // move foward : moving the z (60 units in a second) based on vertical input
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * MouseInput);
            if(Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                anim.SetBool("isJumping", true);

            } 
            else
            {
                anim.SetBool("isJumping", false);
            }
            if (VerticalInput > 0)
            {
                move = (transform.forward * (Time.deltaTime * speed * VerticalInput));
                cc.Move(move);
                anim.SetBool(isWalking, true);
                anim.SetFloat("Speed", 1.0f);
                takeDamage(0.05f);
            }
            else if (VerticalInput < 0)
            {
                move = (transform.forward * (Time.deltaTime * speed * VerticalInput));
                cc.Move(move);
                anim.SetBool(isWalking, true);
                anim.SetFloat("Speed", -1.0f);
            }
            else
            {
                anim.SetBool(isWalking, false);
            }

            if (VerticalInput > 0 && runShift)
            {
                anim.SetBool(isRunning, true);
                move = (transform.forward * (Time.deltaTime * runSpeed * VerticalInput));
                cc.Move(move);
            }
            else
            {
                move = (transform.forward * (Time.deltaTime * speed * VerticalInput));
                cc.Move(move);
                anim.SetBool(isRunning, false);
            }
            

        }

        if (isDead)
        {
            anim.SetTrigger("death");

        }



    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {

        if (hit.transform.CompareTag("heart"))
        {
            heal(5f);
            Destroy(hit.gameObject);
            Debug.Log("healing");
        }
        if (hit.transform.CompareTag("key"))
        {
            Destroy(hit.gameObject);
            key.enabled = true;
            Debug.Log("Got the key");
        }
    }



    public bool isDead
    {
        get
        {
            return currentHealth < 0;
        }
    }

    public void heal(float health)
    {
        this.currentHealth += health;
        this.healthBar.SetHealth(currentHealth);

    }
    public void takeDamage(float damage)
    {
        this.currentHealth -= damage;
        this.healthBar.SetHealth(currentHealth);

    }



}
