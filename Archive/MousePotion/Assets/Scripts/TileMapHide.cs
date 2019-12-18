using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapHide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<MouseController>() != null)
        {
            var tempColor = GetComponent<Tilemap>().color;
            tempColor.a = 0f;
            GetComponent<Tilemap>().color = tempColor;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MouseController>() != null)
        {
            var tempColor = GetComponent<Tilemap>().color;
            tempColor.a = 255f;
            GetComponent<Tilemap>().color = tempColor;
        }
    }
}
