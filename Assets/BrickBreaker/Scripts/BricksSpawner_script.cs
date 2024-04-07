using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksSpawner_script : MonoBehaviour
{
    [SerializeField] GameObject brickPrefab;
    [SerializeField] float spawnProbability = 0.3f;
    public Paddle_script paddle;
    public Ball_script ball;
    public ExtraSpawner_script extraSpawner;
    public BallVelocityRegulator_Script ballVelocityRegulator;

    public Color[] brickColors = new Color[5];
    public int level = 1;
    protected float time = 0f;
    protected AudioSource levelComplete;
    public AudioClip levelCompleteClip;
    void Start()
    {   
        levelComplete = gameObject.AddComponent<AudioSource>();
        levelComplete.clip = levelCompleteClip;
        InitializeColors();
        SpawnBricks();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void InitializeColors()
    {
        brickColors[0] = new Color(0f, 1f, 0.9690642f);
        brickColors[1] = new Color(0f, 1f, 0.2209582f);
        brickColors[2] = new Color(1f, 0f, 0f);
        brickColors[3] = new Color(1f, 0.4925123f, 0f);
        brickColors[4] = new Color(1f, 0f, 0.9301291f);
    }
    void SpawnBricks()
    {   
        if (ball.isRedPotionDestroyed)
        {
            ball.isRedPotionDestroyed = false;
            extraSpawner.isRedPotionSpawned = false;
            ball.WhiteBall();
            ballVelocityRegulator.ResetSpeed();
        }
            
        levelComplete.Play();
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (Random.value < spawnProbability)
                {
                    GameObject newBrick = Instantiate(brickPrefab);
                    SpriteRenderer newBrickRenderer = newBrick.GetComponent<SpriteRenderer>();
                    newBrickRenderer.color = brickColors[Random.Range(0, brickColors.Length)];
                    newBrick.transform.position = new Vector3(-5 + i * 1.415f, 3.364f - j * 0.73968f, 0);
                }
            }
        }
    }
    public void CheckBricks()
    {
        GameObject[] bricks = GameObject.FindGameObjectsWithTag("Brick");
        if (bricks.Length == 0)
        {
            level++;
            if (level < 6)
            {
                paddle.ScalePaddle(1f - 0.05f * level);
            }
            if (spawnProbability < 0.9f)
            {
                spawnProbability += 0.05f;
            }
            SpawnBricks();
        }
    }
    public void SetBricksTriggered(bool isTriggered)
{
    GameObject[] bricks = GameObject.FindGameObjectsWithTag("Brick");
    foreach (GameObject brick in bricks)
    {
        BoxCollider2D boxCollider = brick.GetComponent<BoxCollider2D>();
        if (boxCollider != null)
        {
            boxCollider.isTrigger = isTriggered;
        }
    }
}

}