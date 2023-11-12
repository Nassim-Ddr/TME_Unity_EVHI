using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public GameObject platformPrefab;
    
    public float minDistanceY = .5f;
    public float maxDistanceY = 1.5f;

    public float maxDistanceX = 2f;
    
    void Start()
    {
        Vector3 spawnPosition = new Vector3(); 

        for (int i = 0; i < 50; i++)
        {
            spawnPosition.y += Random.Range(minDistanceY, maxDistanceY);
            spawnPosition.x = Random.Range(-maxDistanceX, maxDistanceX);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        
    }
}
