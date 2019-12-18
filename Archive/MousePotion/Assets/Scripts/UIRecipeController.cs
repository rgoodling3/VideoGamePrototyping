using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*UIRecipeController: This class displays recipe in TMPro text box*/
public class UIRecipeController : MonoBehaviour
{

    TextMeshProUGUI textfield;

    // Start is called before the first frame update
    void Awake()
    {
        textfield = GetComponent<TextMeshProUGUI>();
    }



    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void ChangeText(string NewText)
    {
        textfield.text=NewText;
    }
}
