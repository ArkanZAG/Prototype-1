using System;
using System.Collections;
using System.Collections.Generic;
using RoadScripts;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoadSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> roadPrefabs;
    [SerializeField] private int startSpawnCount;
    [SerializeField] private GameObject player;

    [SerializeField] private List<Road> spawnedRoad = new();

    private void Start()
    {
        Spawn(Vector3.zero);
        
        for (int i = 0; i < startSpawnCount; i++)
        {
            SpawnAtLast();
        }
    }

    private void SpawnAtLast()
    {
        var lastRoad = spawnedRoad[spawnedRoad.Count - 1];
        Spawn(lastRoad.UpperPoint.position);  
    }
    
    private void SpawnBeforeFirst()
    {
        //Mencari tahu posisi road yang pertama
        var firstRoad = spawnedRoad[0];
        //mencari posisi spawn
        var firstRoadPosition = firstRoad.transform.position;
        var spawnPoint = firstRoadPosition - firstRoad.UpperPoint.position;
        //spawn di posisi yang sudah di hitung
        Spawn(spawnPoint);
    }
    
    
    private void Spawn(Vector3 roadSpawnPosition)
    {
        int randomNumber = Random.Range(0, roadPrefabs.Count);
        GameObject originalRoadGameObject = roadPrefabs[randomNumber];
       
        var roadCopy = Instantiate(originalRoadGameObject, roadSpawnPosition, quaternion.identity);
        var roadComponent = roadCopy.GetComponent<Road>();
        spawnedRoad.Add(roadComponent);
    }

    private void Update()
    {
        var lastRoad = spawnedRoad[spawnedRoad.Count - 3];
        if (player.transform.position.y >= lastRoad.MiddlePoint.position.y) 
        {
            SpawnAtLast();
        }
    }
}
