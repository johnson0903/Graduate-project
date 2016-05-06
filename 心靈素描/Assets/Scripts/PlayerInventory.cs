using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour {

	private List<PickUp> inventory = new List<PickUp> ();

	void Start(){
		
	}

//	void OnTriggerEnter2D(Collider2D other){
//		if (other.CompareTag ("Item")) {
//			PickUp item = other.GetComponent<PickUp> ();
//			item.ShowDialog ();
//			inventory.Add (item);
//			Destroy (other.gameObject, 0.5f);
//		}
//	}

	public void PickUpItem(GameObject somthing){
		PickUp item = somthing.GetComponent<PickUp> ();
		item.ShowDialog ();
		inventory.Add (item);
		Destroy (somthing, 0.5f);
	}
}
