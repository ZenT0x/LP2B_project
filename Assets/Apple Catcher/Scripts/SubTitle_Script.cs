using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubTitle_Script : MonoBehaviour
{   
    protected bool big = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {
        // Sprit make bigger and smaller
        if (transform.localScale.x < 1.1f && !big)
        {
            transform.localScale += new Vector3(0.001f, 0.001f, 0);
        }
        else
        {
            big = true;
            transform.localScale -= new Vector3(0.001f, 0.001f, 0);
            if (transform.localScale.x < 0.9f)
            {
                big = false;
            }
        }
    }
}
