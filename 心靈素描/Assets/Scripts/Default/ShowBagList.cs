using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShowBagList : MonoBehaviour
{
	public GameObject bagList;

	private PlayerController playerController;
	// Use this for initialization
	void Start()
	{
		playerController = FindObjectOfType<PlayerController>().gameObject.GetComponent<PlayerController>();
		bagList.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.E)) {
			if (!bagList.activeSelf) {
				playerController.DontMove ();
				bagList.SetActive (true);
			} else {
				playerController.YouCanMove ();
				bagList.SetActive (false);
			}
		}
	}
}
