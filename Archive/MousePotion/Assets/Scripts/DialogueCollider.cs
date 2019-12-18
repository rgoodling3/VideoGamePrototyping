using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCollider : MonoBehaviour
{

		public DialogueTrigger t; 
    void OnTriggerEnter2D(Collider2D other)
    {

            t.TriggerDialogue(); 
            Debug.Log("this is working");

    }
}
