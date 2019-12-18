using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class DialogueManager : MonoBehaviour
{

		private Queue<string> sentences; 
		
		//public Text nameText;
		public Text dialogueText;
		private GameObject box; 
		
		
    // Start is called before the first frame update
    void Start()
    {
    		box = GameObject.Find("DialogueBox");
    		box.active = false; 
        sentences = new Queue<string>(); 
    }

		public void StartDialogue(Dialogue dialogue){
			box.active = true;
			
			sentences.Clear(); 
			
			foreach(string sentence in dialogue.sentences){
				sentences.Enqueue(sentence); 
			}
			
			DisplayNextSentence();
		}
		
		public void DisplayNextSentence(){
			if(sentences.Count == 0){
				EndDialogue();
				return; 
			}
			
			string sentence = sentences.Dequeue();  
			dialogueText.text = sentence;  
		}
		
		public void EndDialogue(){
			box.active = false;
		}
		
		public void Update(){
			if(Input.GetKeyDown(KeyCode.Return)){
				DisplayNextSentence(); 
			}
		}
}
