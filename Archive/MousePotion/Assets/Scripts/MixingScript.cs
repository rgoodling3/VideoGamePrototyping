using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MixingScript : MonoBehaviour
{
    public int level;
    public Image mix1;
    public Image mix2;
    public Image mix3;
    public Image spoon;
    public Image cauldron;
    public Image potion;
    public GameObject potionText;
    public GameObject continueText;

    public float speed;

    public GameObject wayPoint;
    public GameObject spoonWayPoint;
    public GameObject spoonWayPoint2;
    private Vector3 wayPointPos;
    private bool move = false;
    private float lerpControlVal = 0.0f;
    public AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        if (level == 1)
        {
            mix1.GetComponent<Image>().sprite = Resources.Load<Sprite>("mushroom");
            mix2.GetComponent<Image>().sprite = Resources.Load<Sprite>("apple");
            mix3.GetComponent<Image>().sprite = Resources.Load<Sprite>("cabbage");
            potion.GetComponent<Image>().sprite = Resources.Load<Sprite>("potion");
            potionText.GetComponent<TextMeshProUGUI>().text = "Stealth Potion!";
        }
        sound.Play();
        potion.GetComponent<Image>().color = Color.clear;
        potionText.GetComponent<TextMeshProUGUI>().color = Color.clear;
        continueText.GetComponent<TextMeshProUGUI>().color = Color.clear;
        StartCoroutine(Example());
    }

    // Update is called once per frame
    void Update()
    {
        wayPointPos = new Vector3(wayPoint.transform.position.x,
            wayPoint.transform.position.y, wayPoint.transform.position.z);
        speed = 100.0f;
        if (move == true)
        {
            mix1.transform.position = Vector3.MoveTowards(mix1.transform.position,
            wayPointPos, speed * Time.deltaTime);
            mix2.transform.position = Vector3.MoveTowards(mix2.transform.position,
            wayPointPos, speed * Time.deltaTime);
            mix3.transform.position = Vector3.MoveTowards(mix3.transform.position,
            wayPointPos, speed * Time.deltaTime);
        }
        if (mix1.transform.position == wayPointPos)
        {
            move = false;
            spoon.GetComponent<Image>().color = Color.white;
        }
        if (spoon.GetComponent<Image>().color == Color.white)
        {
            Vector3 spoonPos1 = new Vector3(spoonWayPoint.transform.position.x,
                spoonWayPoint.transform.position.y, spoonWayPoint.transform.position.z);
            Vector3 rotate1 = new Vector3(spoonWayPoint.transform.eulerAngles.x,
                spoonWayPoint.transform.eulerAngles.y, spoonWayPoint.transform.eulerAngles.z);
            Vector3 spoonPos2 = new Vector3(spoonWayPoint2.transform.position.x,
                spoonWayPoint2.transform.position.y, spoonWayPoint2.transform.position.z);
            Vector3 rotate2 = new Vector3(spoonWayPoint2.transform.eulerAngles.x,
                spoonWayPoint2.transform.eulerAngles.y, spoonWayPoint2.transform.eulerAngles.z);
            spoon.transform.position = Vector3.Lerp(spoonPos2, spoonPos1, Mathf.PingPong(Time.time, 1));
            spoon.transform.eulerAngles = Vector3.Lerp(rotate2, rotate1, Mathf.PingPong(Time.time, 1));
            if (lerpControlVal < 2)
            {
                lerpControlVal += Time.deltaTime / 2.0f;
            }
            else
            {
                spoon.GetComponent<Image>().color = Color.clear;
                lerpControlVal = 10.0f;
            }
        }
        if (lerpControlVal >= 10.0f)
        {
            mix1.GetComponent<Image>().color = Color.clear;
            mix2.GetComponent<Image>().color = Color.clear;
            mix3.GetComponent<Image>().color = Color.clear;
            cauldron.GetComponent<Image>().color = Color.clear;
            potion.GetComponent<Image>().color = Color.white;
            potionText.GetComponent<TextMeshProUGUI>().color = Color.black;
            continueText.GetComponent<TextMeshProUGUI>().color = Color.black;
        }
        if (Input.GetKeyDown("return"))
        {
            SceneManager.LoadScene(sceneName: "LevelSelect");
        }
    }

    private void OnEnable()
    {
        level = PlayerPrefs.GetInt("level");
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(2);
        move = true;
    }
}
