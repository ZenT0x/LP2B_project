using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowEndMenu()
    {   
        gameObject.SetActive(true);
    }
    public void Restart()
    {   
        Debug.Log("Restart");
        StartCoroutine(LoadScene_Game("AppleCatcher"));
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
