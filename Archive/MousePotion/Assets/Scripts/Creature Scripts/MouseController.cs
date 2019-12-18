using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public float speed = 4.5f;
    
    public GameObject wayPoint; //for the cat follow
    //This is how often your waypoint's position will update to the player's position
 	private float timer = 0.5f;

    public GameObject objectinHand;
    public Vector2 startPos;
    private int flip = 0;
    public Camera mouseCamera;
    public Camera mapView;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        objectinHand = null;
        mouseCamera.enabled = true;
        mapView.enabled = false;
        GetComponent<AudioSource>().volume = 0.15f;
        GetComponent<AudioSource>().Play();
    }

    // Returns the mouse to the starting location (for example, if they die)
    public void goToStart()
    {
        transform.position = startPos;
    }

    public void goToShed()
    {
        transform.position = new Vector3(9.09f, -61.45f, 0);
    }

    public void goOutsideShed()
    {
        transform.position = new Vector3(-5.8f, -3.0f, 0);
    }

    public void holdObject(GameObject gameObject)
    {
        if (objectinHand != null)
        {
            objectinHand.transform.parent = null;
            objectinHand.transform.position = new Vector3(0, 0, -10);
        }
        objectinHand = gameObject;
        objectinHand.transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);
        objectinHand.transform.parent = transform;
    }

    public void putDownObject()
    {
        if (objectinHand != null)
        {
            objectinHand.transform.parent = null;
            objectinHand = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("m"))
        {
            mouseCamera.enabled = false;
            mapView.enabled = true;
        }
        else
        {
            mouseCamera.enabled = true;
            mapView.enabled = false;


            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if (flip == 0 && horizontal < 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                flip = 1;
            }
            else if (flip == 1 && horizontal > 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                flip = 0;
            }
            Vector2 position = rigidbody2d.position;
            position.x = position.x + speed * horizontal * Time.deltaTime;
            position.y = position.y + speed * vertical * Time.deltaTime;

            rigidbody2d.MovePosition(position);
        }        
        
        //cat follow stuff
       	if(timer > 0)
      	{
        	timer -= Time.deltaTime;
      	}
      	if(timer <= 0)
      	{
        	//The position of the waypoint will update to the player's position
     	  	UpdatePosition();
         	timer = 0.5f;
      	}
    }

    void UpdatePosition()
    {
        //The wayPoint's position will now be the player's current position.
        wayPoint.transform.position = transform.position;
    }
}


