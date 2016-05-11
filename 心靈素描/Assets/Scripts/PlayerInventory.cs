using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour {

	private List<GameObject> inventory = new List<GameObject> ();

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

	public void PickUpItem(GameObject item){
		inventory.Add (item);
		Debug.Log ("包包東西 = " + inventory.Count);
		Destroy (item);
	}
}
