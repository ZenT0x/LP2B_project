using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner_script : MonoBehaviour
{
    //import prefab
    public GameObject pipePrefab;
    public float TimerSpawnMini;
    public float TimerSpawnMax;
    public float differenceMultiplier = 0f;
    float timer = 3f;
    public float time = 0f;
    public float newPipePrefabCoordinate = 0f;
    public float difference = 0f;
    public float difficultyGrow = 1000f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime/10f;
        timer -= Time.deltaTime;
        if (timer <= 0)
        {   
            if (time / difficultyGrow < 1)
            {
                differenceMultiplier = time / difficultyGrow;
            }
            else
            {
                differenceMultiplier = 1f - ((time - difficultyGrow) / difficultyGrow) ;
            }
            difference = (3f - Mathf.Abs(newPipePrefabCoordinate)) * differenceMultiplier;
            newPipePrefabCoordinate = Random.Range(-3f + difference, 3f - difference);
            Instantiate(pipePrefab, new Vector3(10, newPipePrefabCoordinate, 0), Quaternion.identity);
            timer = SetRandomTimer();
            
        }

    }
    float SetRandomTimer()
    {
        if (TimerSpawnMini > 1.5f)
        {
            TimerSpawnMax = TimerSpawnMax - time / difficultyGrow;
            TimerSpawnMini = TimerSpawnMini - time / difficultyGrow;
        }
        return Random.Range(TimerSpawnMini, TimerSpawnMax);
    }
}
