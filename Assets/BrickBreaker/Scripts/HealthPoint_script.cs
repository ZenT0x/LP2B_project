using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoint_script : MonoBehaviour
{
    [SerializeField] GameObject healthPointPrefab;
    [SerializeField] GameObject healthPointMissingPrefab;
    public DeadMenu deadMenu;
    AudioSource deadSound;
    AudioSource lossHealthSound;
    public AudioClip deadClip;
    public AudioClip lossHealthClip;

    List<GameObject> healthPointList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {   
        deadSound = gameObject.AddComponent<AudioSource>();
        deadSound.clip = deadClip;
        lossHealthSound = gameObject.AddComponent<AudioSource>();
        lossHealthSound.clip = lossHealthClip;
        for (int i = 0; i < 3; ++i)
        {
            AddHealthPoint();
            GameObject newMissingHealthPoint = Instantiate(healthPointMissingPrefab);
            newMissingHealthPoint.transform.position = new Vector3(5.346f - i * 1f, 4.676f, 0);

        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddHealthPoint()
    {
        if (healthPointList.Count >= 3)
        {
            return;
        }
        GameObject newHealthPoint = Instantiate(healthPointPrefab);
        newHealthPoint.transform.position = new Vector3(5.346f - healthPointList.Count * 1f, 4.676f, 0);
        healthPointList.Add(newHealthPoint);
    }

    public void LoseHealthPoint()
    {
        lossHealthSound.Play();
        GameObject healthPoint = healthPointList[healthPointList.Count - 1];
        healthPointList.RemoveAt(healthPointList.Count - 1);
        Destroy(healthPoint);
        if (isGameOver())
        {
            StartCoroutine(GameOverCoroutine());
            Time.timeScale = 0;
        }

    }
    public bool isGameOver()
    {
        if (healthPointList.Count == 0)
        {
            Debug.Log("Game Over");
            return true;
        }
        return false;
    }
    IEnumerator GameOverCoroutine()
    {
        deadSound.Play();
        deadMenu.ShowDeadMenu();
        yield return new WaitForSecondsRealtime(1);
        
    }
}
