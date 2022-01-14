using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float enemySpawnRate = 0f;
    [SerializeField] private bool canSpawnEnemy;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnEnemies");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnEnemies()
    {
        while(canSpawnEnemy == true)
        {
            yield return new WaitForSeconds(enemySpawnRate);
            Spawn();
        }
    }

    private void Spawn()
    {
        GameObject instance = Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
