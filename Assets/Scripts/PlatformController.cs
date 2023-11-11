using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public GameSettings gameSettings;
    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        jumpForce = gameSettings.jumpForce;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
		}
	}
}
