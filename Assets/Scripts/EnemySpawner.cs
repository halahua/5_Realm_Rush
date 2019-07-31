using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawn = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParent;
    public Transform enemyParticlesParent;

    [SerializeField] AudioClip spawnedEnemySFX;

    [SerializeField] Text spawnedEnemies;
    int score;

    private void Start()
    {
        StartCoroutine(RepeteadlySpawnEnemies());
        spawnedEnemies.text = score.ToString();
    }


    IEnumerator RepeteadlySpawnEnemies()
    {
        while (true)
        {
            AddScore();

            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);

            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity); // para trabalhar com Instantiation você precisa declarar uma variável antes
            newEnemy.transform.parent = enemyParent.transform;
            yield return new WaitForSeconds(secondsBetweenSpawn); // aqui você pode referenciar o tempo que você usar no Inspector
        }
    }

    private void AddScore()
    {
        score++;
        spawnedEnemies.text = score.ToString();
    }
}
