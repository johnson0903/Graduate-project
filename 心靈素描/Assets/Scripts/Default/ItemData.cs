using UnityEngine;
using System.Collections;

public class ItemData : MonoBehaviour {

	public string itemName;
	public string description;

	public void UseItem ()
	{
		
	}

	public bool CanBeUsed {
		get { 
			return false;
		}
	}
}
