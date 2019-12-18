using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShedScript : MonoBehaviour
{

    private bool doorOpen;
    // Start is called before the first frame update
    void Start()
    {
        //shedpos = new Vector3(-1.8f, -84.43f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("open_door_bld"))
        {
            doorOpen = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (doorOpen == true && other.GetComponent<MouseController>() != null)
        {
            MouseController controller = other.GetComponent<MouseController>();
            controller.goToShed();
        }
    }
}
