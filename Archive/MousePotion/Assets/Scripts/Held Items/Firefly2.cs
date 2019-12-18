using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firefly2 : MonoBehaviour
{
    public float speed = 2.0f;
    bool vertical = true;
    public float changeTime = 1.0f;

    Rigidbody2D prigidbody2D;
    float timer;
    int direction = 1;
    bool reverse = false;
    bool caught = false;
    private AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        prigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

    public void catchFly()
    {
        sound.Play();
        caught = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (caught == true)
        {
            Destroy(prigidbody2D);
            enabled = false;
        }

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            if (vertical)
            {
                vertical = false;
            }
            else
            {
                vertical = true;
            }
            if (reverse)
            {
                direction = -direction;
                reverse = false;
            }
            else
            {
                reverse = true;
            }
            timer = changeTime;
        }


        Vector2 position = prigidbody2D.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
        }

        prigidbody2D.MovePosition(position);
    }
}
