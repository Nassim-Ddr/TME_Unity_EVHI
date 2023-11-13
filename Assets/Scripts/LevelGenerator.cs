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
	// list prefab decoration
	public List<GameObject> decorationPrefabList = new List<GameObject>();
	public int number_decoration = 100;
	public float DecorationMinDistanceY = 5f;
	public float DecorationMaxDistanceY = 15f;
    
	void Start()
    {
		GenerateAllPlatform();
		GenerateAllEnemies();
		GenerateAllDecoration();
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

	private void GenerateAllDecoration()
	{
		Vector3 spawnPosition = new Vector3();
		Vector2 screenHalfSizeInWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
		
		float RightBorder = screenHalfSizeInWorldUnits.x;
		float LeftBorder = -screenHalfSizeInWorldUnits.x;
		List<float> values = new List<float>();
		values.Add(RightBorder);
		values.Add(LeftBorder);
		int leafOrRight;
		// Enemy generation
		for (int i = 0; i < number_decoration; i++)
		{
			leafOrRight = Random.Range(0, values.Count);
			spawnPosition.y += Random.Range(EnemyMinDistanceY, EnemyMaxDistanceY);
			// choose random side
			spawnPosition.x = values[leafOrRight];
			// Intantiate a random enemy prefab from the list
			GameObject decorationPrefab = decorationPrefabList[Random.Range(0, decorationPrefabList.Count)];
			GameObject decoration = Instantiate(decorationPrefab, spawnPosition, Quaternion.identity);
			// flip the decoration if it is on the left side
			if (leafOrRight == 1)
			{
				decoration.GetComponent<SpriteRenderer>().flipX = true;
				// move slightly to the right if it is on the left side depending on the size of the decoration
				decoration.transform.position += new Vector3(decoration.GetComponent<SpriteRenderer>().bounds.size.x / 2, 0, 0);
			}
			else {
				// move slightly to the left if it is on the right side
				decoration.transform.position += new Vector3(-decoration.GetComponent<SpriteRenderer>().bounds.size.x / 2, 0, 0);
			}
			
		}
	}
}
