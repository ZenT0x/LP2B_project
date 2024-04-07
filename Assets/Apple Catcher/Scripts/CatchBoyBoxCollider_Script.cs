using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchBoyBoxCollider_Script : MonoBehaviour
{
    public Player_Script playerScript;
    protected AudioSource AppleSound;
    protected AudioSource GoldenAppleSound;
    public AudioClip AppleSoundClip;
    public AudioClip GoldenAppleSoundClip;

    void Start()
    {
        AppleSound = gameObject.AddComponent<AudioSource>();
        AppleSound.clip = AppleSoundClip;
        GoldenAppleSound = gameObject.AddComponent<AudioSource>();
        GoldenAppleSound.clip = GoldenAppleSoundClip;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Apple"))
        {
            playerScript.AddScore();
            AppleSound.Play();
        }
        if (col.collider.CompareTag("GoldenApple"))
        {   
            GoldenAppleSound.Play();
            for (int i = 0; i < 5; i++)
            {
                playerScript.AddScore();
            }
        }
    }

}
