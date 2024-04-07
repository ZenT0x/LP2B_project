using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBackgroundMooving_Script : MonoBehaviour
{
    public float backgroundSpeed = 0.01f;
    public Renderer backgroundRenderer;

    // Update is called once per frame
    public void mooving(float value){
        Debug.Log("mooving");
        backgroundRenderer.material.mainTextureOffset += new Vector2(backgroundSpeed * value, 0f);
    }
}