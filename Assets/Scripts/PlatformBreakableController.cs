using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBreakableController : MonoBehaviour
{

    public List<Sprite> platformBreakLevels;

    private int breakLevel;
    private SpriteRenderer sr;

    public void Start()
    {
        breakLevel = Random.Range(0, 5);
        sr = transform.GetComponent<SpriteRenderer>();
        sr.sprite = platformBreakLevels[breakLevel];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
                pc.Jump();
                breakLevel += 1;
                if (breakLevel == platformBreakLevels.Count) BreakPlatform();
                else sr.sprite = platformBreakLevels[breakLevel];
            }
        }
    }

    private void BreakPlatform()
    {
        transform.GetComponent<EdgeCollider2D>().enabled = false;
        transform.GetComponent<Animator>().enabled = true;
        gameObject.AddComponent<Rigidbody2D>();
        Destroy(this, 2);
    }
}
