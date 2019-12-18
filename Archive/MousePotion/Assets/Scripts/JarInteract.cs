using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarInteract : MonoBehaviour
{
    Collider2D mouseCollider;
    public GameObject mouse;
    public InventoryDisplay inventory;
    public Sprite oneFirefly;
    public Sprite twoFireflies;
    public Sprite noFireflies;
    public Sprite threeFireflies;
    public GameObject building;
    public GameObject shovel;

    private void Start()
    {
        mouseCollider = mouse.GetComponent<Collider2D>();
    }
    private void Update()
    {
        if(GetComponent<SpriteRenderer>().sprite == threeFireflies)
        {
            building.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("open_door_bld");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKeyDown("f") && collision == mouseCollider)
        {
            string name = inventory.held();
            if (name == "firefly1" || name == "firefly2" || name == "firefly3" ||
                name == "twofireflies" || name == "threefireflies")
            {
                updateJar(name);
            }
        }
    }

    void updateJar(string item)
    {
        inventory.itemRemoved(item);
        if (GetComponent<SpriteRenderer>().sprite == noFireflies)
        {
            if(item == "twofireflies")
            {
                GetComponent<SpriteRenderer>().sprite = twoFireflies;
            }
            else if(item=="threefireflies")
            {
                GetComponent<SpriteRenderer>().sprite = threeFireflies;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = oneFirefly;
            }
        }
        else if (GetComponent<SpriteRenderer>().sprite == oneFirefly)
        {
            if (item == "twofireflies")
            {
                GetComponent<SpriteRenderer>().sprite = threeFireflies;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = twoFireflies;
            }
        }
        else
        {
            GetComponent<AudioSource>().Play();
            GetComponent<SpriteRenderer>().sprite = threeFireflies;
        }
    }
}
