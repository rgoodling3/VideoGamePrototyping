using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    private float speed = 3.0f;
    public float changeTime = 2.0f;

    float timer;
    public int MaxX, MinX, MaxY, MinY;
    private Vector3 wayPointPos;

    // Use this for initialization
    void Start()
    {
        timer = changeTime;
        wayPointPos = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            wayPointPos = new Vector2(Random.Range(MinX, MaxX), Random.Range(MinY, MaxY));
            timer = changeTime;
        }

        if (timer < changeTime)
        {
            transform.position = Vector2.MoveTowards(transform.position, wayPointPos, speed);
        }
    }
}
