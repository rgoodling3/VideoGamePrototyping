using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientCollectible : MonoBehaviour
{
   public GameObject recipeManagerObject;
   private RecipeManager rm;
   public string ingredientName = "test";

     void Awake ()
    {
        rm = recipeManagerObject.GetComponent<RecipeManager>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown("f"))
        {
            Destroy(gameObject);
            rm.itemCollected(ingredientName);
        }
        
    }
}
