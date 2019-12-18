using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMove : MonoBehaviour
{
    private GameObject wayPoint;
    private Vector3 wayPointPos;
    //Kitty speed!
    private float speed = 1.0f;
    private Vector3 startpos = new Vector3(-10.1f, -24f, 0);
    private AudioSource sound;

    void Start()
    {
        //At the start of the game, the cat will find the gameobject called wayPoint.
        wayPoint = GameObject.Find("wayPoint");
        sound = GetComponent<AudioSource>();
    }

    void Update()
    {
        wayPointPos = new Vector3(wayPoint.transform.position.x,
        wayPoint.transform.position.y, wayPoint.transform.position.z);
        //Here, the cat will follow the waypoint.
        if (wayPointPos[1] < -12.0 && wayPointPos[1] > -37.0)
        {
            if (wayPointPos[1] < -20.0 && wayPointPos[1] > -37.0)
                speed = 8.0f;
            transform.position = Vector3.MoveTowards(transform.position,
            wayPointPos, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<MouseController>() != null)
        {
            sound.Play();
            MouseController controller = other.GetComponent<MouseController>();
            controller.goToStart();
            speed = 1.0f;
            gameObject.transform.position = startpos;
        }
    }
}
