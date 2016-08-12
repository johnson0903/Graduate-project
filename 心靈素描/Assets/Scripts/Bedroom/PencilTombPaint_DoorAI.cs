using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;

public class PencilTombPaint_DoorAI : MonoBehaviour {

	private GameObject player;
	private DialogHolder dialogHolder;
	private static bool hasDialogPopUpInPencilTombPaint;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ().gameObject;
		dialogHolder = this.GetComponent<DialogHolder> ();
		this.GetComponent<DialogHolder> ().DialogOverEvent += OnDialogOver;

		player.transform.position = new Vector3 (this.transform.position.x, player.transform.position.y, player.transform.position.z);

		if(!hasDialogPopUpInPencilTombPaint)
			dialogHolder.IsAutoPopUp = true;
	}

	// Update is called once per frame
	void Update () {

		if (!hasDialogPopUpInPencilTombPaint)
			dialogHolder.Dialogs = new List<Dialog> {
				dialogHolder.TalkDialog (".......?"),
				dialogHolder.TalkDialog ("這裡是哪裡"),
			};
		else
			dialogHolder.Dialogs = new List<Dialog> {
				dialogHolder.TalkDialog (".........."),
			dialogHolder.AskDialog ("回去", "待著", new List<Dialog> {
					dialogHolder.TalkDialog ("再調查一下好了")
				}), dialogHolder.TalkDialog ("..................")
			};
	}
		
	void OnDialogOver (object sender, EventArgs e)
	{
		if (!hasDialogPopUpInPencilTombPaint)
			hasDialogPopUpInPencilTombPaint = true;
		else if (dialogHolder.AskDialogAnswerList [0] == 1) {
			player.GetComponent<PlayerController> ().MoveToOriginPositionX ();
			SceneManager.LoadScene (0);
		}
	}
}

