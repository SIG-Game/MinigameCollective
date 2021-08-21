using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnWaleed : MonoBehaviour
{
    public float spawnRadius = 3;
    public float time = 5;
    public GameObject enemy;
    public GameObject spawner;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        Vector2 spawnPos = spawner.transform.position;
        Instantiate(enemy, spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(time);
        time -= 0.03f;
        StartCoroutine(SpawnEnemy());
    }
}
