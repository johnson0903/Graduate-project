﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

	public GameObject dBox;
	public Text dText;
	public Image itemImage;
	public GameObject player;

	public bool dialogActive;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (dialogActive && Input.GetMouseButtonDown(0)) {	
			dBox.SetActive(false);
			dialogActive = false;
			player.GetComponent<PlayerController> ().TalkingOver ();
		}
	}

	public void ShowBox(string dialog) {
		dialogActive = true;
		dBox.SetActive (true);
		dText.text = dialog;
	}

	public void ShowBox(string dialog, Sprite itemSprite){
		dialogActive = true;
		dBox.SetActive (true);
		dText.text = dialog;
		itemImage.sprite = itemSprite;
	}
}
