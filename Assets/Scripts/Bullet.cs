using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeDuration = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // we delete the bullet after a certain amount of time
        lifeDuration -= Time.deltaTime;
        if (lifeDuration <= 0)
		{
			Destroy(gameObject);
		}
    }
}
