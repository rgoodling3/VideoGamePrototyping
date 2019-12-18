using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMove : MonoBehaviour
{
    private GameObject wayPoint;
    private Vector3 wayPointPos;
    private float speed = 1.0f;
    private Vector3 startpos = new Vector3(19.67f, -3.533f, 0);

    // Start is called before the first frame update
    void Start()
    {
        //At the start of the game, the snake will find the gameobject called wayPoint.
        wayPoint = GameObject.Find("wayPoint");
    }

    // Update is called once per frame
    void Update()
    {
        wayPointPos = new Vector3(wayPoint.transform.position.x,
        wayPoint.transform.position.y, wayPoint.transform.position.z);
        //Here, the snake will follow the waypoint.
        if (wayPointPos[1] < -2.5 && wayPointPos[1] > -4.1)
        {
            if (wayPointPos[0] > 17.0)
            {
                speed = 8.0f;
                transform.position = Vector3.MoveTowards(transform.position,
                wayPointPos, speed * Time.deltaTime);
            } 
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<MouseController>() != null)
        {
            MouseController controller = other.GetComponent<MouseController>();
            controller.goToStart();
            speed = 1.0f;
            gameObject.transform.position = startpos;
        }
    }
}
