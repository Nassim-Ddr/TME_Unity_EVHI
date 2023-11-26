using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public string powerup_name;
    public int powerup_duration;
    public Vector3 powerup_relative_position;

    private PlayerController playerController;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        if (collision.gameObject.CompareTag("Player"))
        {
            playerController = collision.gameObject.GetComponent<PlayerController>();

            if (playerController.powerUp == "")
            {
                transform.SetParent(collision.gameObject.transform);
                transform.localPosition = powerup_relative_position;

                playerController.activatePowerup(powerup_name);

                transform.GetComponent<Collider2D>().enabled = false;

                StartCoroutine(WaitDuration());
            }
        }
    }
    IEnumerator WaitDuration()
    {
        yield return new WaitForSeconds(powerup_duration);
        
        cleanPowerUp();
    }

    void cleanPowerUp()
    {
        //Maybe add animation here 
        playerController.clearPowerup();
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        transform.parent = null;
        gameObject.AddComponent<Rigidbody2D>();
        Destroy(this, 2);
    }
}
