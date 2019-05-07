using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Physics : MonoBehaviour
{
    public float firstDuration;
    public float duration;
    public float acceleration;
    public float deceleration;
    private Rigidbody rb;
    private bool moving;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("CheckSpeed", firstDuration, duration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        Movement();
        MovementDeceleration();
    }

    void Movement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (moveHorizontal != 0.0f || moveVertical != 0.0f)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * acceleration);
    }

    void MovementDeceleration()
    {
        if (moving == false)
        {
            rb.angularDrag = deceleration;
        }
        else
        {
            rb.angularDrag = 0.05f;
        }
    }

    void CheckSpeed()
    {
        Debug.Log("Velocidad en x: " + rb.velocity.x);
        Debug.Log("Velocidad en y: " + rb.velocity.y);
        Debug.Log("Velocidad en z: " + rb.velocity.z);
    }
}
