using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeadMenu : MonoBehaviour
{
    public Ball_script ball_script;
    public TextMeshProUGUI final_score;
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowDeadMenu()
    {   
        ball_script.backgroundMusic.Stop();
        gameObject.SetActive(true);
        final_score.SetText("Score : " + ball_script.score);
    }
    public void Restart()
    {   
        Debug.Log("Restart");
        StartCoroutine(LoadScene_Game("BrickBreaker"));
    }

    IEnumerator LoadScene_Game(string sceneName)
    {
        Debug.Log("LoadScene_Game");
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        Time.timeScale = 1;

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
