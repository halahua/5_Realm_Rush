using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;
    Queue<Tower> towerQueue = new Queue<Tower>();
    [SerializeField] Transform towerParent;


    public void AddTower(Waypoint baseWaypoint)
    {
        int numTowers = towerQueue.Count;        


        if (numTowers < towerLimit)
        {
            InstantiateNewTowers(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }

    // baseWaypoint aqui embaixo vai ser a forma de se comunicar com o Waypoint.cs
    // o Waypoint verde vira um TIPO <T>, o mesmo usado nos outros scripts
    // naquela parte pra determinar o tipo específico de objeto que vai ser colocado no Inspector
    // e.g. [SerializeField] Tower towerPrefab;
    // Tower é o tipo, nesse exemplo
    // Scripts podem ser classificados como classe também
    private void InstantiateNewTowers(Waypoint baseWaypoint)
    {
        var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParent.transform;
        baseWaypoint.isPlaceable = false;

        newTower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;

        towerQueue.Enqueue(newTower);
    }

    private void MoveExistingTower(Waypoint newBaseWaypoint)
    {
        Tower oldTower = towerQueue.Dequeue();

        oldTower.baseWaypoint.isPlaceable = true;
        newBaseWaypoint.isPlaceable = false;

        oldTower.baseWaypoint = newBaseWaypoint;

        oldTower.transform.position = newBaseWaypoint.transform.position;

        towerQueue.Enqueue(oldTower);
    }
}
