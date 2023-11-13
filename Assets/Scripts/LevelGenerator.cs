using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public GameObject platformPrefab;

    public float probaPlatformMobile = 0.2f;
    public GameObject platformMobilePrefab; 
    
    public float PlatformMinDistanceY = .5f;
    public float PlateformMaxDistanceY = 1.5f;

    public float PlatformMaxDistanceX = 2f;

    public int number_enemies = 100;
	public float EnemyMaxDistanceFromMiddle = 2f;
	public float EnemyMinDistanceY = 5f;
	public float EnemyMaxDistanceY = 15f;
	// list prefab enemy
	public List<GameObject> enemyPrefabList = new List<GameObject>();
    

	void Start()
    {
		GenerateAllPlatform();
		GenerateAllEnemies();
	}

    void GenerateAllPlatform()
	{
		Vector3 spawnPosition = new Vector3();

		// Platform generation
		for (int i = 0; i < 500; i++)
		{
			spawnPosition.y += Random.Range(PlatformMinDistanceY, PlateformMaxDistanceY);
			spawnPosition.x = Random.Range(-PlatformMaxDistanceX, PlatformMaxDistanceX);

			float proba = Random.Range(0.0f, 1.0f);
			if (proba <= probaPlatformMobile) Instantiate(platformMobilePrefab, spawnPosition, Quaternion.identity);
			else Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
		}
	}

	void GenerateAllEnemies(){
		Vector3 spawnPosition = new Vector3();
		// Enemy generation
		for (int i = 0; i < number_enemies; i++)
		{
			spawnPosition.y += Random.Range(EnemyMinDistanceY, EnemyMaxDistanceY);
			spawnPosition.x = Random.Range(-EnemyMaxDistanceFromMiddle, EnemyMaxDistanceFromMiddle);

			// Instantiate a random enemy prefab from the list
			GameObject enemyPrefab = enemyPrefabList[Random.Range(0, enemyPrefabList.Count)];
			Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
		}
	}
}
