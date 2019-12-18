using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firefly : MonoBehaviour
{
    float count = 0.0f;
    Vector3 startPoint;
    Vector3 endPoint;
    Vector3 midPoint;

    private AudioSource sound;

    bool caught = false;
    Rigidbody2D prigidbody2D;

    private int moveStatus;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        moveStatus = 0;
        startPoint = transform.position;
        endPoint = new Vector3(transform.position.x - 4f, transform.position.y, transform.position.z);
        midPoint = startPoint + (endPoint - startPoint) / 2 + Vector3.up * 5.0f;
        prigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void catchFly()
    {
        sound.Play();
        caught = true;
    }

    void OnBecameVisible()
    {
        StartCoroutine(ChangeMove());
    }

    IEnumerator ChangeMove()
    {
        if (moveStatus == 0)
        {
            yield return new WaitForSeconds(1);
            moveStatus = 1;
        }
    }

    void Update()
    {
        if (caught == true)
        {
            moveStatus = 0;
            enabled = false;
        }
        if (moveStatus == 1)
        {
            if (count < 1.0f)
            {
                count += 0.5f * Time.deltaTime;

                Vector3 m1 = Vector3.Lerp(startPoint, midPoint, count);
                Vector3 m2 = Vector3.Lerp(midPoint, endPoint, count);
                transform.position = Vector3.Lerp(m1, m2, count);
            }
            else
            {
                moveStatus = 2;
                startPoint = transform.position;
                endPoint = new Vector3(transform.position.x - 8f, transform.position.y, transform.position.z);
                midPoint = startPoint + (endPoint - startPoint) / 2 + Vector3.up * -5.0f;
                count = 0.0f;
            }
        }
        else if(moveStatus == 2)
        {
            if (count < 1.0f)
            {
                count += 0.25f * Time.deltaTime;

                Vector3 m1 = Vector3.Lerp(startPoint, midPoint, count);
                Vector3 m2 = Vector3.Lerp(midPoint, endPoint, count);
                transform.position = Vector3.Lerp(m1, m2, count);
            }
            else
            {
                Vector3 temp = startPoint;
                startPoint = endPoint;
                endPoint = temp;
                count = 0.0f;
            }
        }
    }
}
