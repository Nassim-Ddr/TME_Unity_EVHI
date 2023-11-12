using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
	public GameObject gameOverUI;
	public Text ScoreUI;
	public Scene scene;
	public GameScoreManager ScoreManager;
	bool gameOver;


	// Start is called before the first frame update
	void Start()
	{
		FindObjectOfType<PlayerController>().OnPlayerDeath += OnGameOver;
	}

	// Update is called once per frame
	void Update()
	{
		if (gameOver)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				SceneManager.LoadScene(0);
			}
		}
	}

	void OnGameOver()
	{
		gameOverUI.SetActive(true);
		ScoreUI.text = ScoreManager.score.ToString("0");
		gameOver = true;
	}
}
