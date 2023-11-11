using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameSettings gameSettings;
    public Rigidbody2D rb;

    private float moveX;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = gameSettings.playerSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * speed;
    }

    private void FixedUpdate()
	{
		rb.velocity = new Vector2(moveX, rb.velocity.y);
	}
}
