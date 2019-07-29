using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] float movementPeriod = .5f;
    [SerializeField] ParticleSystem goalParticlePrefab;

    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        print("Start patrol...");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(movementPeriod);
        }
        EnemyReachedGoal();
        print("Ending patrol...");
    }

    private void EnemyReachedGoal()
    {
        var enemySpawnerReference = FindObjectOfType<EnemySpawner>();

        var goalVfx = Instantiate(goalParticlePrefab, transform.position, Quaternion.identity);
        goalVfx.transform.parent = enemySpawnerReference.enemyParticlesParent.transform;
        goalVfx.Play();

        Destroy(goalVfx.gameObject, goalVfx.main.duration);
        Destroy(gameObject, 1f);
    }
}
