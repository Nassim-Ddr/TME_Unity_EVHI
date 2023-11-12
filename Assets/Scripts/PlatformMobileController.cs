using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMobileController : MonoBehaviour
{
    public float speed = 5;
    Vector3 target;

    private void Start()
    {
        target = transform.position;
        target.x = 3;
    }

    void Update()
    {
        if (Math.Abs(transform.position.x) >= 3) target.x *= -1;
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }
}
