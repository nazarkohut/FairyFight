using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MobSpawn : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform[] spawnPoints;
    public bool isCreating = false;
    private int now = 0;
    private int prev = 0;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (!isCreating)
        {
            isCreating = true;
            SpawnMethod();
            Task.Delay(4000).ContinueWith(t =>
            {
                isCreating = false;

            });
        }
        if (Timer.currentTime > (now+1) * 100)
        {
            now += 1;
        }
        if (now!=prev)
        {
            prev = now;
            GameObject enemy = Instantiate(enemies[4]);
            enemy.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
        }

    }

    void SpawnMethod()
    {
  
        GameObject enemy =  Instantiate(enemies[Random.Range(0, enemies.Length-1)]);
        enemy.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
    }
}
