using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldCollectible : MonoBehaviour
{
    public string itemName;
    public string[] itemRequirements = new string[0];
    public string heldReq = "";
    private bool reqs = true;

    public InventoryDisplay inventory;
    private void Start()
    {
        reqs = true;
    
    }

    void OnTriggerStay2D(Collider2D other)
    {
    
        MouseController m = other.GetComponent<MouseController>();
        if (Input.GetKeyDown("f") && m != null)
        {
            foreach (string item in itemRequirements)
            {
                if(!inventory.hasItem(item))
                {
                    reqs = false;
                }
            }
            if(!inventory.held().Equals(heldReq) && heldReq!="")
            {
                reqs = false;
            }
            if (reqs)
            {
                inventory.itemAdded(itemName, gameObject);
                Firefly fly = GetComponent<Firefly>();
                Firefly2 fly2 = GetComponent<Firefly2>();
                if(fly != null)
                {
                    fly.catchFly();
                }
                if(fly2 != null)
                {
                    fly2.catchFly();
                }
            }
            reqs = true;
        }

    } 
    

          
}
