using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawn = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParent;
    public Transform enemyParticlesParent;

    private void Start()
    {
        StartCoroutine(RepeteadlySpawnEnemies());
    }


    IEnumerator RepeteadlySpawnEnemies()
    {
        while (true)
        {
            // para trabalhar com Instantiation você precisa declarar uma variável antes
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParent.transform;
            yield return new WaitForSeconds(secondsBetweenSpawn); // aqui você pode referenciar o tempo que você usar no Inspector
        }
    }
}
