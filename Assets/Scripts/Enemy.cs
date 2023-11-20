using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 1;
    public bool isMoving = false;
    public int scoreValue = 100;
    float speed = 1.5f;
    float timeToMove = 3f;
    float t = 0f;
    Color baseColor;
    GameScoreManager ScoreManager;
    // Start is called before the first frame update
    void Start()
    {
        ScoreManager = FindObjectOfType<GameScoreManager>();
        baseColor = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
		{
            ScoreManager.AddBonus(scoreValue);
            ScoreManager.updateScore();
			Destroy(gameObject);
		}

        if (isMoving)
        {
            MoveRightToleft();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Bullet")
		{
			Destroy(collision.gameObject);
			// change the color of the enemy for a short time
            // learp back to the base color
            
            StartCoroutine(ChangeColor());
			health--;
            
		}
	}

    IEnumerator ChangeColor()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        GetComponent<SpriteRenderer>().color = baseColor;
	}

    void MoveRightToleft()
	{
        if (t < timeToMove)
		{
			transform.Translate(Vector2.right * speed * Time.deltaTime);
		}
		else
		{
			transform.Translate(Vector2.left * speed * Time.deltaTime);
		}
        t += Time.deltaTime;
        if (t > timeToMove * 2)
        {
			t = 0;
        }

	}
}
