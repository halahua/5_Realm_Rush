using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] Collider collisionMesh;
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        hitParticlePrefab.Play();
    }


    void KillEnemy()
    {
        // para falar com outro script, precisa referenciar ele!!!!!!!!!!
        var enemySpawnerReference = FindObjectOfType<EnemySpawner>();

        var deathVfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        deathVfx.transform.parent = enemySpawnerReference.enemyParticlesParent.transform;
        deathVfx.Play();

        Destroy(deathVfx.gameObject, deathVfx.main.duration);
        Destroy(gameObject, 1f);
    }
}
