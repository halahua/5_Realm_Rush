﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Waypoint : MonoBehaviour {


    Vector2Int gridPos;
    const int gridSize = 10;


    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }


    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Up").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }


    public int GetGridSize()
    {
        return gridSize;
    }
}
