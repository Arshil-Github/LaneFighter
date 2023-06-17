using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public float spawnTimePeriod;
    public GameObject[] pf_enemies;
    public Transform[] spawnPositions;

    public void Start()
    {
        StartCoroutine(SpawnAfterDelay());
    }
    IEnumerator SpawnAfterDelay()
    {
        Debug.Log(213);
        yield return new WaitForSeconds(spawnTimePeriod);

        SpawnEnemy();

        StopAllCoroutines();
        StartCoroutine(SpawnAfterDelay());
    }
    public void SpawnEnemy()
    {
        int enemyDecider = Random.Range(0, spawnPositions.Length - 1);
        int posDecider = Random.Range(0, 3);
        Debug.Log(enemyDecider);
        Debug.Log(posDecider);
        GameObject spawedEnemy = Instantiate(pf_enemies[enemyDecider], spawnPositions[posDecider].position, Quaternion.identity);
    }
}
