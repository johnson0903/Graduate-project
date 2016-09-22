using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShowBagList : MonoBehaviour
{
	private GameObject bagList;
	private PlayerController playerController;
	private DialogManager dialogManager;
	// Use this for initialization
	void Start()
	{
		bagList = this.transform.FindChild ("BagList").gameObject;
		playerController = FindObjectOfType<PlayerController>();
		dialogManager = FindObjectOfType<DialogManager>();
		bagList.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		if (!dialogManager.dBox.activeSelf) {
			if (!bagList.activeSelf) {
				if (Input.GetKeyDown (KeyCode.E)) {
					playerController.DontMove ();
					bagList.SetActive (true);
				}
			} else {
				if (Input.GetKeyDown (KeyCode.E) || Input.GetKeyDown (KeyCode.Escape)) {
					playerController.YouCanMove ();
					bagList.SetActive (false);
					playerController.gameObject.GetComponent<PlayerInventory> ().RecoverSelectedItemCount ();
				}
			}
		}
	}
}
