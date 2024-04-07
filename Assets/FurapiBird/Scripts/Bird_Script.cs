using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bird_Script : MonoBehaviour
{   
    public BirdSprite_script birdSprite;
    public DeadMenu_script deadMenu;
    public Game_script game_script;
    protected AudioSource collision_sound;
    public AudioClip collision_sound_clip;
    public float jumpPower = 5;
    Rigidbody2D rg;


    bool isDead = false;


    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        collision_sound = gameObject.AddComponent<AudioSource>();
        collision_sound.clip = collision_sound_clip;
        collision_sound.loop = false;
        StartCoroutine(StartGame());

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isDead)
        {
            rg.velocity = Vector2.up * jumpPower;
        }
        if (transform.position.y > 5.5f || transform.position.y < -5.5f && !isDead)
        {
            GameOver();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pipe" && !isDead)
        {
            GameOver();
        }
        Debug.Log("Collision");
    }

    void GameOver()
    {   
        game_script.background_music.Stop();
        collision_sound.Play();
        StartCoroutine(GameOverCoroutine());
        Time.timeScale = 0;
    }


    IEnumerator GameOverCoroutine()
    {   
        isDead = true;
        StartCoroutine(birdSprite.DeadBird());
        yield return new WaitForSecondsRealtime(1);
        transform.rotation = Quaternion.Euler(0, 0, -45);
        Physics.IgnoreLayerCollision(0, 9);
        for (int i = 0; i < 100; i++)
        {   
            transform.position += Vector3.down * 0.1f;
            yield return new WaitForSecondsRealtime(0.01f);
        }
        deadMenu.ShowDeadMenu();
    }
    IEnumerator StartGame()
    {   
        Time.timeScale = 0;
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                break;
            }
            yield return null;
        }
        Time.timeScale = 1;
        rg.velocity = Vector2.up * jumpPower;
        game_script.background_music.Play();
        birdSprite.StartGame();
    }
}   