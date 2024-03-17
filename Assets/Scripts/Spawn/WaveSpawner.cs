using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyPrefab;

    [SerializeField]
    private Transform spawnPoint1;
    [SerializeField] 
    private Transform spawnPoint2;

    [SerializeField]
    private float timeBetweenWaves = 5f;
    private float countdown = 2f;

    [SerializeField]
    private int waveIndex = 1;

    void Update()
    {
        if(countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        foreach (var enemy in enemyPrefab)
        {
            Instantiate(enemy, new Vector2(spawnPoint1.position.x, enemy.transform.position.y), spawnPoint1.rotation, transform);
            Instantiate(enemy, new Vector2(spawnPoint2.position.x, enemy.transform.position.y), spawnPoint2.rotation, transform);
        }
    }
}