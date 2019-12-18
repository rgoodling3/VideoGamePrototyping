using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageDisplay : MonoBehaviour
{
    
    public void ShowMessage(string Sentence)
    {
        DialogueTrigger T = GameObject.Find("DialogueTrigger").GetComponent<DialogueTrigger>();
        
        T.dialogue.sentences[0] = Sentence; 
        
        T.TriggerDialogue(); 
    }




}
