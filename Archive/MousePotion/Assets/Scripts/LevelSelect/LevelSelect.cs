using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect: MonoBehaviour
{
    public int selLevel;
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Text3;
    public GameObject Image1;
    public GameObject Image2;
    public GameObject Image3;
    public GameObject NotReady;
    public GameObject box;
    Color myColor = new Color(0.2735849f, 0.2735849f, 0.2735849f, 1);

    // Start is called before the first frame update
    void Start()
    {
        selLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("return"))
        {
            if (selLevel == 1)
            {
                SceneManager.LoadScene(sceneName:"StoryScene1");
            }
            else
            {
                NotReady.GetComponent<TextMeshProUGUI>().color = Color.black;
                box.GetComponent<Image>().color = new Color(0.3568628f, 0.3490196f, 0.2784314f, 0.7921569f);
                StartCoroutine(Example());
            }
        }
        if (selLevel == 1)
        {
            Text1.GetComponent<TextMeshProUGUI>().color = Color.black;
            Text1.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Bold;

            Image1.GetComponent<Image>().color = Color.white;
            Image2.GetComponent<Image>().color = myColor;
            Image3.GetComponent<Image>().color = myColor;

            if (Input.GetKeyDown("d"))
            {
                Text1.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Normal;
                Text1.GetComponent<TextMeshProUGUI>().color = myColor;
                selLevel = 2;
            }
        }
        else if (selLevel == 2)
        {
            Text2.GetComponent<TextMeshProUGUI>().color = Color.black;
            Text2.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Bold;

            Image1.GetComponent<Image>().color = myColor;
            Image2.GetComponent<Image>().color = Color.white;
            Image3.GetComponent<Image>().color = myColor;

            if (Input.GetKeyDown("d"))
            {
                Text2.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Normal;
                Text2.GetComponent<TextMeshProUGUI>().color = myColor;
                selLevel = 3;
            }
            if (Input.GetKeyDown("a"))
            {
                Text2.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Normal;
                Text2.GetComponent<TextMeshProUGUI>().color = myColor;
                selLevel = 1;
            }
        }
        else if (selLevel == 3)
        {
            Text3.GetComponent<TextMeshProUGUI>().color = Color.black;
            Text3.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Bold;

            Image1.GetComponent<Image>().color = myColor;
            Image2.GetComponent<Image>().color = myColor;
            Image3.GetComponent<Image>().color = Color.white;

            if (Input.GetKeyDown("a"))
            {
                Text3.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Normal;
                Text3.GetComponent<TextMeshProUGUI>().color = myColor;
                selLevel = 2;
            }
        }
    }
    IEnumerator Example()
    {
        yield return new WaitForSeconds(2);
        NotReady.GetComponent<TextMeshProUGUI>().color = Color.clear;
        box.GetComponent<Image>().color = Color.clear;
    }
}
