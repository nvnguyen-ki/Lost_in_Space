using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// inherit from MonoBehavioor
public class PlayerController : MonoBehaviour
{
    float speed = 15.0f;
    private float turnSpeed = 45f;
    private float MouseInput;
    private float VerticalInput;
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    // Start is called before the first frame update

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;

    }

    // Update is called once per frame
    void Update()
    {

        
        // update the vehicle movement
        MouseInput = Input.GetAxis("Mouse X");
        VerticalInput = Input.GetAxis("Vertical");

        // move foward : moving the z (60 units in a second) based on vertical input
        transform.Translate(Vector3.forward * (Time.deltaTime * speed * VerticalInput));

        // turn : rotate the car based on horizontal input
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * MouseInput);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround) {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

    

}
    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
}
