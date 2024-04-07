using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallVelocityRegulator_Script : MonoBehaviour
{
    public float maxSpeed = 3f;
    public float minSpeed = 2f;
    public float horizontalTolerance = 0.1f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Give the ball an initial speed
    }

    void FixedUpdate()
    {
        //Limit the speed of the ball
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
            Debug.Log("Ball velocity is limited to " + maxSpeed);
        }
        if (rb.velocity.magnitude < minSpeed)
        {
            rb.velocity = rb.velocity.normalized * minSpeed;
            Debug.Log("Ball velocity is limited to " + minSpeed);
        }
        //Make sure the ball is always moving downward
        if (rb.velocity.x > 2 && rb.velocity.y <= horizontalTolerance)
        {
            rb.velocity = new Vector2(rb.velocity.x, -3);
            Debug.Log("HORIZONTAL VELOCITY IS TOO HIGH");
        }
    }
    public void ResetSpeed()
    {
        maxSpeed = 8f;
        minSpeed = 8f;
    }
}