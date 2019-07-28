using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;
    Queue<Tower> towerQueue = new Queue<Tower>();


    public void AddTower(Waypoint baseWaypoint)
    {
        print(towerQueue.Count);
        int numTowers = towerQueue.Count;        


        if (numTowers < towerLimit)
        {
            InstantiateNewTowers(baseWaypoint);
        }
        else
        {
            MoveExistingTower();
        }
    }

    private void InstantiateNewTowers(Waypoint baseWaypoint)
    {
        var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        baseWaypoint.isPlaceable = false;

        towerQueue.Enqueue(newTower);
    }

    private void MoveExistingTower()
    {
        var oldTower = towerQueue.Dequeue();
        towerQueue.Enqueue(oldTower);
        print("Limit reached");
    }
}
