using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMooving_script : MonoBehaviour
{
    public float backgroundSpeed = 0.01f;
    public Renderer backgroundRenderer;

    public Material backgroundMaterial1;
    public Material backgroundMaterial2;
    public Material backgroundMaterial3;
    public Material backgroundMaterial4;
    public Material backgroundMaterial5;

    void Start()
    {   
        Material[] materials = {backgroundMaterial1, backgroundMaterial2, backgroundMaterial3, backgroundMaterial4, backgroundMaterial5};
        backgroundRenderer.material = materials[Random.Range(0, materials.Length)];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       backgroundRenderer.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime, 0f);
    }
}
