using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraSpawner_script : MonoBehaviour
{   
    public GameObject redPotion_prefab;
    protected float time;
    public bool isRedPotionSpawned = false;
    
    void Start()
    {
        time = Random.Range(1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRedPotionSpawned)
        {
            time -= Time.deltaTime;
        }
        if (time <= 0 && !isRedPotionSpawned)
        {
            GameObject redPotion = Instantiate(redPotion_prefab);
            redPotion.transform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(-1f,3f), 0);
            isRedPotionSpawned = true;
            time = Random.Range(15f, 25f);
        }
    }
}
