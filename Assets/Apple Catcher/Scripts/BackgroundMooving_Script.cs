using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMooving_Script : MonoBehaviour
{
    public float backgroundSpeed = 0.01f;
    public Renderer backgroundRenderer;

    // Update is called once per frame
    void FixedUpdate()
    {
       backgroundRenderer.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime, 0f);
    }
}
