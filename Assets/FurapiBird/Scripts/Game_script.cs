using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Game_script : MonoBehaviour
{   
    public TextMeshPro TMP_distance;
    public AudioSource background_music;
    public AudioClip background_music_clip;
    float distance = 0;

    void Start()
    {
        background_music = gameObject.AddComponent<AudioSource>();
        background_music.clip = background_music_clip;
        background_music.loop = true;
        background_music.volume = 0.5f;
    }

    void Update()
    {   
        //Quit game
        if (Input.GetKeyDown(KeyCode.Escape))
        {   
            Debug.Log("Quit");
            StartCoroutine(LoadScene_Game("Menu"));
        }

        distance += Time.deltaTime;
        TMP_distance.SetText("Distance: " + distance.ToString("F1"));
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
