using UnityEngine;
using System.Collections;

public class DogeAI : MonoBehaviour {

	private GameObject player;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ().gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown ()
	{
		if (player.GetComponent<PlayerInventory> ().isSomethingInInventory ("Bone")) {
			this.GetComponent<DialogHolder>().dialogLines[0] = "好吃好吃";
			this.GetComponent<DialogHolder>().dialogLines[1] = "讓你過";
			this.GetComponent<SpriteRenderer> ().color = new Color(255, 255, 255, 1);
			this.GetComponent<BoxCollider2D> ().isTrigger = true;
		}
	}
}
