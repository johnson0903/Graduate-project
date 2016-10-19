using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Room_PopupDialogAI : MonoBehaviour {

	private DialogHolder dialogHolder;

	private static bool hasDialogPopUpInRoom;

	// Use this for initialization
	void Start () {
		dialogHolder = this.GetComponent<DialogHolder> ();
		this.GetComponent<DialogHolder> ().DialogOverEvent += OnDialogOver;

		if(SceneManager.GetActiveScene ().buildIndex == 1 && !hasDialogPopUpInRoom)
			dialogHolder.IsAutoPopUp = true;
	}

	// Use this for initialization
	void Update () {
		if (!hasDialogPopUpInRoom)
			dialogHolder.Dialogs = new List<Dialog> {
			dialogHolder.TalkDialog ("明明是完全沒有見過的房間"),
			dialogHolder.TalkDialog ("卻感到一股莫名的熟悉感..."),
			dialogHolder.TalkDialog ("先調查看看吧")
		};
		else
			dialogHolder.Dialogs = null;
	}

	void OnDialogOver (object sender, EventArgs e)
	{
		hasDialogPopUpInRoom = true;
	}
}
