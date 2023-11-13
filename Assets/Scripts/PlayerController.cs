using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameSettings gameSettings;
	[HideInInspector]
    public Rigidbody2D rb;

	float screenHalfWidthInWorldUnits;
	Vector3 screenPosition;
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

		// we update the sprite flipX property to flip the sprite
		// if the player is moving to the left
		if (moveX < 0)
		{
			GetComponent<SpriteRenderer>().flipX = true;
		}
		else if (moveX > 0)
		{
			GetComponent<SpriteRenderer>().flipX = false;
		}
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

		// calculate the screen position of the player
		screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		// if the player drop down the screen then it dies
		if (screenPosition.y < 0)
		{
			PlayerDie();
		}

	}

	void OnTriggerEnter2D(Collider2D triggerCollider)
	{
		//Debug.Log(triggerCollider);
		if (triggerCollider.gameObject.tag == "Enemies")
		{
			//Debug.Log("Enemy");
			PlayerDie();
		}

		if (triggerCollider.gameObject.tag == "Platform")
		{
			// play the jump sound
			Debug.Log("Jump");
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
