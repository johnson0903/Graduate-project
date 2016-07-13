using UnityEngine;
using System.Collections;

public class RedBookAI : MonoBehaviour {

	public GameObject boxCutter;

	private GameObject player;
	private static bool isBoxCutterTaken;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ().gameObject;
	}

	// Update is called once per frame
	void Update () {
		
		if (!isBoxCutterTaken && this.GetComponent<DialogHolder> ().IsDialogOver) {
			GameObject gameObject = Instantiate (boxCutter);
			gameObject.name = boxCutter.name;
			isBoxCutterTaken = true;
			player.GetComponent<PlayerInventory> ().PickUpItem (gameObject);
		} 
		else if (isBoxCutterTaken)
			this.GetComponent<DialogHolder> ().dialogLines = new string[] { "這裡已經沒有東西了" };
	}

}
