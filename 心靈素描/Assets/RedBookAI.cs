using UnityEngine;
using System.Collections;

public class RedBookAI : MonoBehaviour {

	public GameObject key;

	private GameObject player;
	private static bool isRedBookKeyTaken;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ().gameObject;
	}

	// Update is called once per frame
	void Update () {
		
		if (!isRedBookKeyTaken && this.GetComponent<DialogHolder> ().IsDialogOver) {
			GameObject k = Instantiate (key);
			k.name = key.name;
			isRedBookKeyTaken = true;
			player.GetComponent<PlayerInventory> ().PickUpItem (k);
		} 
		else if (isRedBookKeyTaken)
			this.GetComponent<DialogHolder> ().dialogLines = new string[] { "這裡已經沒有東西了" };
	}

}
