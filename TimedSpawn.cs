using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawn : MonoBehaviour
{
    public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    private int count = 0;
    public int maxSpawn = 10;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject",spawnTime,spawnDelay);
    }

    public void SpawnObject(){
        Instantiate(spawnee, transform.position, transform.rotation);
        count++;
        if (stopSpawning){
            CancelInvoke("SpawnObject");
        }
        if(count == maxSpawn)
        {
            stopSpawning = true;
            //Destroy(gameObject);
        }
    }
}
