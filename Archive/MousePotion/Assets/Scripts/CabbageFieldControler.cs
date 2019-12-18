using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabbageFieldControler : MonoBehaviour
{

    public GameObject recipeManager;
    public GameObject inventoryManager;
    private InventoryDisplay inventory;
    private RecipeManager rm;
    private string toolName = "shovel";
    private AudioSource sound;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }



    void OnTriggerStay2D(Collider2D other)
    {
        rm = recipeManager.GetComponent<RecipeManager>();
        inventory = inventoryManager.GetComponent<InventoryDisplay>();
        MouseController m = other.GetComponent<MouseController>();
        string heldItem = inventory.held();

        if (Input.GetKeyDown("f") && m!=null && heldItem == toolName)
        {
            sound.Play();
            rm.itemCollected("Cabbage");
        }
    }
}
