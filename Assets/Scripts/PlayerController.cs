using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// inherit from MonoBehavioor
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // update the vehicle movement

        // move foward : moving the z (60 units in a second)
        // transform.Translate(0, 0, 1) is the same as the code below
        transform.Translate(Vector3.forward * (Time.deltaTime * 20));
    }
}
