using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Ball_script : MonoBehaviour
{
    public TextMeshPro displayed_text;
    public float ballReorientation = 3f;
    public BricksSpawner_script brickSpawner;
    public HealthPoint_script healthPoint;
    public BallVelocityRegulator_Script ballVelocityRegulator;
    protected float time = 2f;
    protected bool isFallen = false;
    public int score = 0;
    protected AudioSource bounceOnPad;
    protected AudioSource bounceOnBrick;
    protected AudioSource redPotion;
    public AudioSource backgroundMusic;
    public bool isRedPotionDestroyed = false;
    public AudioClip bounceOnPadClip;
    public AudioClip bounceOnBrickClip;
    public AudioClip redPotionClip;
    public Color redColor;
    public AudioClip backgroundMusicClip;
    
    

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        InitializeMusic();
        rb = GetComponent<Rigidbody2D>(); // Get the rigidbody component
        rb.velocity = new Vector2(0,0);
        redColor = new Color(1f, 0.3537736f, 0.3537736f);
        isFallen = true;

    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quit");
            StartCoroutine(LoadScene_Game("Menu"));
        }
    }
    void FixedUpdate()
    {   
        if (transform.position.y < -10.0f)
        {
            isFallen = true;
            healthPoint.LoseHealthPoint();
            transform.position = new Vector3(0, -2, 0);
            rb.velocity = new Vector3(0, 0, 0);
            rb.isKinematic = true; // Stop the ball from moving
        }
        if (isFallen)
        {
            fallen();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Brick"))
        {
            Destroy(col.gameObject);
            bounceOnBrick.Play();
            AddScore();
        }
        if (col.collider.CompareTag("Paddle"))
        {
            Rigidbody2D ref_rigidBody = rb;
            float diffX = transform.position.x - col.transform.position.x;
            ref_rigidBody.velocity += new Vector2(diffX * ballReorientation, 0);
            bounceOnPad.Play();
        }
        brickSpawner.CheckBricks();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("RedPotion"))
        {
            Destroy(col.gameObject);
            brickSpawner.SetBricksTriggered(true);
            isRedPotionDestroyed = true;
            redPotion.Play();
            SpriteRenderer ballRenderer = GetComponent<SpriteRenderer>();
            ballRenderer.color = redColor;
            BallVelocityRegulator_Script ballVelocityRegulator = GetComponent<BallVelocityRegulator_Script>();
            ballVelocityRegulator.maxSpeed = 13f;
            ballVelocityRegulator.minSpeed = 13f;
        }
        if (col.CompareTag("Brick"))
        {
            Destroy(col.gameObject);
            bounceOnBrick.Play();
            AddScore();
        }
    }

    protected void AddScore()
    {
        score += 50;
        displayed_text.SetText("Score : " + score);
    }
    IEnumerator LoadScene_Game(string sceneName)
    {
        Debug.Log("LoadScene_Game");
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    protected void fallen()
    {
        Debug.Log("isFallen");
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Debug.Log("time <= 0");
            isFallen = false;
            time = 2f;
            rb.isKinematic = false; // Allow the ball to move again
            rb.velocity = new Vector2(0, -1);
        }
    }
    public void WhiteBall()
    {
        SpriteRenderer ballRenderer = GetComponent<SpriteRenderer>();
        ballRenderer.color = Color.white;
    }
    void InitializeMusic()
    {
        bounceOnPad = gameObject.AddComponent<AudioSource>();
        bounceOnPad.clip = bounceOnPadClip;
        bounceOnBrick = gameObject.AddComponent<AudioSource>();
        bounceOnBrick.clip = bounceOnBrickClip;
        redPotion = gameObject.AddComponent<AudioSource>();
        redPotion.clip = redPotionClip;
        backgroundMusic = gameObject.AddComponent<AudioSource>();
        backgroundMusic.clip = backgroundMusicClip;
        backgroundMusic.loop = true;
        backgroundMusic.Play();
    }
}
