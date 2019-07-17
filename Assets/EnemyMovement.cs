using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] List<Waypoint> path;


    void Start()
    {
        StartCoroutine(FollowPath());
        print("Back at Start.");
    }

    IEnumerator FollowPath()
    {
        print("Start patrol...");
        foreach (Waypoint waypoint in path)
        {
            print("Visiting block: " + waypoint);
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f);
        }
        print("End patrol.");
    }
}
