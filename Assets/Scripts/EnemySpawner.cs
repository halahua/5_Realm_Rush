using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawn = 2f;
    [SerializeField] EnemyMovement enemyPrefab;

    private void Start()
    {
        StartCoroutine(RepeteadlySpawnEnemies());
    }


    IEnumerator RepeteadlySpawnEnemies()
    {
        while (true)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(secondsBetweenSpawn); // aqui você pode referenciar o tempo que você usar no Inspector
        }
    }
}
