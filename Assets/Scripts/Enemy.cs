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
    GameScoreManager ScoreManager;
    // Start is called before the first frame update
    void Start()
    {
        ScoreManager = FindObjectOfType<GameScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
		{
            ScoreManager.AddBonus(scoreValue);
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
			health--;
            
		}
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
