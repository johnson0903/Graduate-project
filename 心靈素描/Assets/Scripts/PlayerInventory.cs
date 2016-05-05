using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour {

	private PlayerController playerController;
	private List<PickUp> inventory = new List<PickUp> ();

	void Start(){
		playerController = GetComponent<PlayerController> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Item")) {
			playerController.Talking ();
			PickUp item = other.GetComponent<PickUp> ();
			item.ShowDialog ();
			inventory.Add (item);
			Destroy (other.gameObject, 0.5f);
		}
	}
}
