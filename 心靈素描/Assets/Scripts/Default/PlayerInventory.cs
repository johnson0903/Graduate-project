using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour {

	public GameObject bag;

	private List<GameObject> inventory = new List<GameObject> ();
	private int selectedItemCount = 1;

	void Update()
	{
		if (bag.activeSelf)
			SelectItem ();
	}

	public void PickUpItem(GameObject pickUpItem){
		GameObject item = new GameObject(pickUpItem.name, typeof(Image));
		item.GetComponent<RectTransform> ().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 100, 300);
		item.GetComponent<RectTransform> ().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 100, 300);
		item.transform.SetParent (bag.transform);
		item.transform.localPosition = new Vector3 (-400 + inventory.Count % 5 * 120, 90 - inventory.Count / 5 * 110, 0.0f);
		item.transform.localScale = new Vector3(0.3f, 0.3f, 0.0f);
		item.GetComponent<Image> ().sprite = pickUpItem.GetComponent<SpriteRenderer> ().sprite;
		bag.transform.FindChild ("ItemDescription").GetChild(0).GetComponent<Text>().text = "6666666";
		Destroy (pickUpItem);
		inventory.Add (item);
	}

	public void DropItem(string name) {
		for (int i = 0; i < inventory.Count; i++)
		{
			if (inventory [i].name == name)
			{	
				Destroy (inventory [i]);
				inventory.RemoveAt (i);
			}
		}
		Debug.Log (inventory.Count);
	}

	public void SelectItem() {
		
		if ((Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && selectedItemCount > 5) {
			selectedItemCount -= 5;
		} else if ((Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && selectedItemCount <= inventory.Count - 5) {
			selectedItemCount += 5;
		} else if ((Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && selectedItemCount > 1) {
			selectedItemCount -= 1;
		} else if ((Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && selectedItemCount < inventory.Count) {
			selectedItemCount += 1;
		}
		for (int i = 1; i < inventory.Count + 1; i++) {
			if (i == selectedItemCount)
				bag.transform.GetChild (i + 1).GetComponent<Image> ().color = Color.green;
			else
				bag.transform.GetChild (i + 1).GetComponent<Image> ().color = Color.white;
		}
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
