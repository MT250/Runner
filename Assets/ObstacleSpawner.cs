using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] int obstaclesAmount;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] List<GameObject> obstacles;
    public void AddObstacle(int _amount)
    {
        obstaclesAmount += _amount;

        var go = Instantiate(obstaclePrefab);
        obstacles.Add(go);
    }
}
