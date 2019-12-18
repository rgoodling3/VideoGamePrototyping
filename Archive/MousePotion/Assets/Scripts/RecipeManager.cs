using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*The object contains the name of the recipe and ingredients for the level.
When item is picked up, it checks if it belongs to the recipe and if yes, it changes textbox
*/
public class RecipeManager : MonoBehaviour
{
     /*Recipe UI which will show the text*/
    public GameObject uiRecipe;
    private UIRecipeController recipeController; //script to display text

    private string potionName;
    private string[] ingredients;
    private Dictionary<string, bool> ingredientsDict;
    private bool allIngredientsCollected;

    /*Set Recipe for this level*/
    public void setRecipe(string potionName, string[] ingredients)
    {
        if(recipeController != null)
        {
        this.ingredients = ingredients;
        this.potionName = potionName;

         //no ingredients are collected in the beginning
        allIngredientsCollected = false;

        //create dict to manage state of ingredient: picked up = True, not picked up = False
        ingredientsDict = new Dictionary<string, bool> ();
        for (int i = 0; i < ingredients.Length; i++)
        {
            string tmp = ingredients[i];
            ingredientsDict[tmp] = false;
        }

        //display ingredients & state
         recipeController.ChangeText(IngredientsToText());
        }
    }

    public void itemCollected(string itemName)
    {
        if(ingredientsDict.ContainsKey(itemName))
        {
            ingredientsDict[itemName] = true;

            //display ingredients & state
            string ing = IngredientsToText();
            recipeController = uiRecipe.GetComponent<UIRecipeController>();
            GetComponent<AudioSource>().Play();
            recipeController.ChangeText(ing);

            //check if all ingredients are collected
            bool collectedAllFlag = true;
            foreach(KeyValuePair<string, bool> entry in ingredientsDict)
            {
                if(entry.Value == false)
                {
                    collectedAllFlag = false;
                }
            }

            if(collectedAllFlag)
            {
                allIngredientsCollected = true;
                showEndLevelMessage();
            }
            
        }
    }

    private void showEndLevelMessage()
    {
        MessageDisplay M =  gameObject.AddComponent<MessageDisplay>();
        M.ShowMessage("You've picked up all ingredients, you can go home!"); 
        //todo - show pop up box message
    }

    public bool getCollectionStatus()
    {
        return allIngredientsCollected;
    }

    private string IngredientsToText()
    {
        string heading = @"<line-height=150%><align=""center""><style=""H2""><b>"+potionName+@"</b></align><br></style><align=""left"">";
        string IngredientList = "";

        foreach(KeyValuePair<string, bool> entry in ingredientsDict)
        {
            IngredientList = IngredientList+@"- "+ entry.Key;
            //if the item is collected show tick
            if(entry.Value)
            {
               IngredientList = IngredientList + @"<sprite name=""TICKOFF""><br>";
             }
             else
             {
                 IngredientList = IngredientList+@"<br>";
             }
        }

        return heading+IngredientList;
    }


     void Awake ()
    {
        recipeController = uiRecipe.GetComponent<UIRecipeController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //name and ingredients hardcoded for now
        setRecipe("Stealth potion", new string[] { "Poisonous Mushroom", "Cabbage","Apple"});
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
