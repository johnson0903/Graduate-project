using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LivingRoom_TVLightTrigger : MonoBehaviour {
	
	public GameObject TV;

	private DialogHolder dialogHolder;

	private static bool hasDialogPopUpInLivingRoom;

	// Use this for initialization
	void Start () {
		dialogHolder = this.GetComponent<DialogHolder> ();
		this.GetComponent<DialogHolder> ().DialogOverEvent += OnDialogOver;

		if(SceneManager.GetActiveScene ().buildIndex == 6 && !hasDialogPopUpInLivingRoom)
			dialogHolder.IsAutoPopUp = true;
	}

	// Use this for initialization
	void Update () {
		if (!hasDialogPopUpInLivingRoom)
			dialogHolder.Dialogs = new List<Dialog> {
				dialogHolder.TalkDialog ("這裡是........."),
				dialogHolder.TalkDialog ("客廳...？"),
			};
		else
			dialogHolder.Dialogs = null;
	}

	void OnDialogOver (object sender, EventArgs e)
	{
		hasDialogPopUpInLivingRoom = true;
	}
}
