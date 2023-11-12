using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public GameObject platformPrefab;

    public float probaPlatformMobile = 0.2f;
    public GameObject platformMobilePrefab; 
    
    public float minDistanceY = .5f;
    public float maxDistanceY = 1.5f;

    public float maxDistanceX = 2f;

    void Start()
    {
        Vector3 spawnPosition = new Vector3(); 
        

        for (int i = 0; i < 500; i++)
        {
            spawnPosition.y += Random.Range(minDistanceY, maxDistanceY);
            spawnPosition.x = Random.Range(-maxDistanceX, maxDistanceX);

            float proba = Random.Range(0.0f, 1.0f);
            if (proba <= probaPlatformMobile) Instantiate(platformMobilePrefab, spawnPosition, Quaternion.identity);
            else Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
