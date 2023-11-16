using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameScoreManager : MonoBehaviour
{
	public GameObject ScoreUI;
	public Text ScoreUIText;
    // get the player controller
    public PlayerController playerController;
    public float scoreMultiplier = 10.0f;

    bool gameOver;
    float bestHeight = 0;
    [HideInInspector]
    public float score = 0;
    [HideInInspector]
    float bonusScore = 0;

    void Start()
    {
		FindObjectOfType<PlayerController>().OnPlayerDeath += OnGameOver;
	}

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
		{
			// score is the maximum height of the player
            if (playerController.transform.position.y > bestHeight)
            {
				// if the player is moving up, update the score
				score = playerController.transform.position.y * scoreMultiplier + bonusScore;
				ScoreUIText.text = score.ToString("0");
				bestHeight = playerController.transform.position.y;
			}
		}
	}

    void OnGameOver()
    {
    	ScoreUI.SetActive(false);
        gameOver = true;
	}

    public void AddBonus(int bonus)
	{
		bonusScore += bonus;
	}
}
