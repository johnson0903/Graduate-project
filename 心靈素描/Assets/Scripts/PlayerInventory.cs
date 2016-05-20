using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour {

	public GameObject bag;

	private List<GameObject> inventory = new List<GameObject> ();

	void Start(){
		
	}
		
	public void PickUpItem(GameObject pickUpItem){
		GameObject item = new GameObject(pickUpItem.name, typeof(Image));
		item.transform.SetParent (bag.transform);
		item.transform.localPosition = new Vector3 (-70 + inventory.Count % 4 * 45, 60 - inventory.Count / 4 * 45, 0.0f);
		item.transform.localScale = new Vector3(0.3f, 0.3f, 0.0f);
		item.GetComponent<Image> ().sprite = pickUpItem.GetComponent<SpriteRenderer> ().sprite;
		Destroy (pickUpItem);
		inventory.Add (item);
	}

	public bool isSomethingInInventory(string name) {
		bool isFound = false;
		for (int i = 0; i < inventory.Count; i++)
		{
			if (inventory [i].name == name)
				isFound = true;
		}
		return isFound;
	}


}
