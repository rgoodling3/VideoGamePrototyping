using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseController : MonoBehaviour
{

   public GameObject recipeManagerObject;
   private RecipeManager rm;

    void Awake ()
    {
        rm = recipeManagerObject.GetComponent<RecipeManager>();
    }

    private void endLevel()
    {
        Debug.Log("LEVEL END");
        SceneManager.LoadScene(sceneName:"MixingScene");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(rm.getCollectionStatus()) //all ingredients collected
        {
            endLevel();
        }
    }

}





 

