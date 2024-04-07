using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSprite_script : MonoBehaviour
{   
    Animator ref_animator;


    void Start()
    {
        ref_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator DeadBird()
    {   
        ref_animator.SetBool("isDead", true);
        yield return null;
    }
    public void StartGame()
    {
        ref_animator.SetBool("isDead", false);
        ref_animator.SetFloat("animationSpeed", 1);
    }
}
