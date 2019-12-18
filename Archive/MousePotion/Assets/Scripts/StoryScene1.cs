using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryScene1 : MonoBehaviour
{
    public Image background;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Example());
        background.GetComponent<Image>().sprite = Resources.Load<Sprite>("bg1");
        count = 0;
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(sceneName: "newScene");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("return"))
        {
            count++;
        }

        if (count == 1)
        {
            background.GetComponent<Image>().sprite = Resources.Load<Sprite>("bg2");
        }

        if (count == 2)
        {
            background.GetComponent<Image>().sprite = Resources.Load<Sprite>("bg3");
        }

        if (count > 2)
        {
            SceneManager.LoadScene(sceneName: "newScene");
        }
    }
}
