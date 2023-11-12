using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameSettings gameSettings;
    public Rigidbody2D rb;

	float screenHalfWidthInWorldUnits;
	Vector2 screenHalfSizeInWorldUnits;

	public event System.Action OnPlayerDeath;

	private float moveX;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = gameSettings.playerSpeed;

		// calculate the screen bounds
		float halfPlayerWidth = transform.localScale.x / 2f; // half the player width
		screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
		screenHalfSizeInWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
	}

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * speed;
    }

    private void FixedUpdate()
	{
		rb.velocity = new Vector2(moveX, rb.velocity.y);

		if (transform.position.x < -screenHalfWidthInWorldUnits)
		{
			transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
		}

		if (transform.position.x > screenHalfWidthInWorldUnits)
		{
			transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
		}

		// if the player goes out of bounds, kill the player
		if (transform.position.y < -screenHalfSizeInWorldUnits.y)
		{
			PlayerDie();
		}

	}

	void OnTriggerEnter2D(Collider2D triggerCollider)
	{
		if (triggerCollider.tag == "Enemies")
		{
			PlayerDie();
		}
	}

	void PlayerDie(){
		if (OnPlayerDeath != null)
		{
			OnPlayerDeath();
		}
		Destroy(gameObject);
	}
}
