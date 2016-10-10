using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LivingRoom_TVLightTrigger : MonoBehaviour {
	
	public GameObject TV;

	private DialogHolder dialogHolder;

	private static bool isTVTurnedOn;

	// Use this for initialization
	void Start () {
		dialogHolder = this.GetComponent<DialogHolder> ();
		this.GetComponent<DialogHolder> ().DialogOverEvent += OnDialogOver;

		if(SceneManager.GetActiveScene ().buildIndex == 6 && !isTVTurnedOn)
			dialogHolder.IsAutoPopUp = true;
	}

	// Use this for initialization
	void Update () {
		if (!isTVTurnedOn)
			dialogHolder.Dialogs = new List<Dialog> {
				dialogHolder.TalkDialog ("好黑........."),
				dialogHolder.TalkDialog ("什麼都看不見..."),
			};
		else
			dialogHolder.Dialogs = null;
	}

	void OnDialogOver (object sender, EventArgs e)
	{
		TV.GetComponent<LivingRoom_TVAI> ().IsTVTurnedOn = true;
		isTVTurnedOn = true;
	}
}
