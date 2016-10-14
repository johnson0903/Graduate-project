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
		GameObject item = Instantiate (pickUpItem);
		item.name = pickUpItem.name;
		if (!item.GetComponent<Image> ())
			item.AddComponent <Image> ();
		item.GetComponent<RectTransform> ().SetInsetAndSizeFromParentEdge (RectTransform.Edge.Top, 100, 300);
		item.GetComponent<RectTransform> ().SetInsetAndSizeFromParentEdge (RectTransform.Edge.Left, 100, 300);
		item.transform.SetParent (bag.transform);
		item.transform.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2 (90 + inventory.Count % 5 * 115, -140 - inventory.Count / 5 * 110);
		item.transform.localScale = new Vector3 (0.3f, 0.3f, 0.0f);
		item.GetComponent<Image> ().sprite = pickUpItem.GetComponent<SpriteRenderer> ().sprite;
		Destroy (pickUpItem);
		inventory.Add (item);
	}

	public void DropItem(string name) {
		for (int i = 0; i < inventory.Count; i++) {
			if (inventory [i].name == name) {	
				Destroy (inventory [i]);
				inventory.RemoveAt (i);
				break;
			}
		}

		for (int i = 0; i < inventory.Count; i++)
			inventory[i].GetComponent<Image>().rectTransform.anchoredPosition = new Vector2 (90 + i % 5 * 115, -140 - i / 5 * 110);
	}

	public void SelectItem() {
		
		if ((Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W)) && selectedItemCount > 5)
			selectedItemCount -= 5;
		else if ((Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.S)) && selectedItemCount <= inventory.Count - 5)
			selectedItemCount += 5;
		else if ((Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.A)) && selectedItemCount > 1)
			selectedItemCount -= 1;
		else if ((Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.D)) && selectedItemCount < inventory.Count)
			selectedItemCount += 1;
		

		if (inventory.Count != 0) {
			bag.transform.FindChild ("ItemDescription").FindChild ("ImageBackGround").gameObject.SetActive (true);
			bag.transform.FindChild ("ItemDescription").FindChild ("Image").gameObject.SetActive (true);
			bag.transform.FindChild ("ItemDescription").FindChild ("Name").gameObject.SetActive (true);
			bag.transform.FindChild ("ItemDescription").FindChild ("Description").gameObject.SetActive (true);

			bag.transform.FindChild ("ItemDescription").FindChild ("Image").GetComponent<Image> ().sprite = inventory [selectedItemCount - 1].GetComponent<SpriteRenderer> ().sprite;
			bag.transform.FindChild ("ItemDescription").FindChild ("Name").GetComponent<Text> ().text = inventory [selectedItemCount - 1].GetComponent<ItemData> ().itemName;
			bag.transform.FindChild ("ItemDescription").FindChild ("Description").GetComponent<Text> ().text = inventory [selectedItemCount - 1].GetComponent<ItemData> ().description;

			for (int i = 1; i < inventory.Count + 1; i++) {
				if (i == selectedItemCount)
					inventory [i - 1].GetComponent<Image> ().color = Color.white;
				else
					inventory [i - 1].GetComponent<Image> ().color = new Color (0.5f, 0.5f, 0.5f, 0.5f);
			}

		} else {
			bag.transform.FindChild ("ItemDescription").FindChild ("ImageBackGround").gameObject.SetActive (false);
			bag.transform.FindChild ("ItemDescription").FindChild ("Image").gameObject.SetActive (false);
			bag.transform.FindChild ("ItemDescription").FindChild ("Name").gameObject.SetActive (false);
			bag.transform.FindChild ("ItemDescription").FindChild ("Description").gameObject.SetActive (false);
		}
	}

	public void RecoverSelectedItemCount(){
		selectedItemCount = 1;
	}

	public bool IsSomethingInInventory(string name) {
		bool isFound = false;
		for (int i = 0; i < inventory.Count; i++)
		{
			if (inventory [i].name == name)
				isFound = true;
		}
		return isFound;
	}

	public GameObject GetSomethingInInventory(string name) {
		GameObject o = null;
		for (int i = 0; i < inventory.Count; i++)
		{
			if (inventory [i].name == name) {
				o = inventory [i];
				break;
			}
		}
		return o;
	}
		
}
