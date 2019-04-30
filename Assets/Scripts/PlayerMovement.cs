using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region VARIABLES
    public float speed;
    public float acceleration;
    public float deceleration;
    private float forward;
    private float lateral;
    private Rigidbody rb;
    private Vector3 vel;
    #endregion

    #region TIMES METHODS
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = vel;
        Acceleration();
        Movement();
    }
    #endregion

    #region METHODS
    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(speed, rb.velocity.y, rb.velocity.z);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(-speed, rb.velocity.y, rb.velocity.z);
        }
    }

    void Acceleration()
    {
        forward = Input.GetAxis("Forward");
        lateral = Input.GetAxis("Lateral");

        if (Input.GetAxisRaw("Lateral") != 0)
        {
            vel.x = acceleration * lateral;
        }
        else
        {
            vel.x = deceleration * lateral;
        }
        if (Input.GetAxisRaw("Forward") != 0)
        {
            vel.z = acceleration * forward;
        }
        else
        {
            vel.z = deceleration * forward;
        }

        vel.x = Mathf.Clamp(vel.x, -speed, speed);
        vel.z = Mathf.Clamp(vel.z, -speed, speed);
    }
    #endregion
}
