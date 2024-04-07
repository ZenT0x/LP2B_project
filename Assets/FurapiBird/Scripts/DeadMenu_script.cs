using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu_script : MonoBehaviour
{
    public Game_script game_script;
    protected AudioSource dead_sound;
    public AudioClip dead_sound_clip;
    void Start()
    {
        gameObject.SetActive(false);
        dead_sound = gameObject.AddComponent<AudioSource>();
        dead_sound.clip = dead_sound_clip;
        dead_sound.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowDeadMenu()
    {   
        dead_sound.Play();
        gameObject.SetActive(true);
        game_script.TMP_distance.transform.position = new Vector3(0.8f, 1.2f, 0);
    }
    public void Restart()
    {   
        Debug.Log("Restart");
        StartCoroutine(LoadScene_Game("FurapiBird"));
    }

    IEnumerator LoadScene_Game(string sceneName)
    {
        Debug.Log("LoadScene_Game");
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
