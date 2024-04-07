using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player_Script : MonoBehaviour
{

    //---------------------------------------------------------------------------------
    // ATTRIBUTES
    //---------------------------------------------------------------------------------
    public TextMeshPro displayed_text;
    public GameBackgroundMooving_Script ref_background;
    public TextMeshPro timeLeft_text;
    public EndMenu_script endMenu;

    public int score = 0;
    public float timeLeft = 120f;
    protected Animator ref_animator;

    void Start()
    {
        ref_animator = GetComponent<Animator>();
    }

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
        timeLeft -= Time.deltaTime;
        timeLeft_text.SetText(Mathf.FloorToInt(timeLeft / 60) + " : " + Mathf.FloorToInt(timeLeft % 60));
        //Manage movement speed and animations
        float newSpeed = 0;
        if (timeLeft <= 0)
        {   
            ref_animator.speed = 0;
            endMenu.ShowEndMenu();
            displayed_text.color = Color.white;
            displayed_text.outlineColor = Color.black;
            displayed_text.outlineWidth = 0.2f;
            displayed_text.fontSize = 8f;
            displayed_text.transform.position = new Vector3(0.9f, 1.49f, 0);
            Time.timeScale = 0;
        }
        
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -8f)
        {
            newSpeed = -10f;
            ref_animator.SetBool("isForwards", false);
            ref_background.mooving(newSpeed);

        }
        else if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 8f)
        {
            newSpeed = 10f;
            ref_animator.SetBool("isForwards", true);
            ref_background.mooving(newSpeed);
        }

        //Inform animator : Are we moving?
        ref_animator.SetBool("isMoving", newSpeed != 0);


        //Move with the speed found
        transform.Translate(newSpeed * Time.deltaTime, 0, 0);

    }
    public void AddScore()
    {
        Debug.Log("AddScore");
        score++;
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

}
