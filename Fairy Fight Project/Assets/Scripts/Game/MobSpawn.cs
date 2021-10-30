using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MobSpawn : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform[] spawnPoints;
    public bool isCreating = false;

    
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
    }

    void SpawnMethod()
    {
  
        GameObject enemy =  Instantiate(enemies[Random.Range(0, enemies.Length)]);
        enemy.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
    }
}
