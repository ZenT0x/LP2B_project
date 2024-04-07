using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : MonoBehaviour
{
    void FixedUpdate()
    {
        if (transform.position.y < -10.0f)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("CatchBoy Box Collider"))
        {   
            Destroy(gameObject);
        }
    }
}
