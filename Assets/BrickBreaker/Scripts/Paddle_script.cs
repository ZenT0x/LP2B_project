using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle_script : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {   
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }
    public void ScalePaddle(float scale)
    {
        transform.localScale = new Vector3(scale, scale, 1);
    }
}
