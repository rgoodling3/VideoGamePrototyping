using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstItem : MonoBehaviour
{
		public MessageDisplay M; 
	 	void OnTriggerStay2D(Collider2D other)
    {
      M.ShowMessage("Press f to pick up items!"); 
    }
}
