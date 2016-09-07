using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class DialogHolder : MonoBehaviour
{
	public event EventHandler DialogOverEvent;

	private DialogManager dialogManager;
	private List<Dialog> dialogs;
	private bool isPlayerInRange;
	private bool isAutoPopUp;

	void Start()
	{
		dialogManager = FindObjectOfType<DialogManager>();
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (!isAutoPopUp && dialogs != null) {
				if (!dialogManager.IsDialogActive && isPlayerInRange)
					dialogManager.StartDialog (this.gameObject);
				else
					dialogManager.ContinueDialog (this.gameObject);
			}
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (isAutoPopUp && dialogs != null && isPlayerInRange) {
			dialogManager.StartDialog (this.gameObject);
			isAutoPopUp = false;
		}
	}

	public Dialog TalkDialog(string talkContent)
	{
		Dialog dialog = new Dialog();
		dialog.Mode = "Talk";
		dialog.Content = talkContent;
		return dialog;
	}

	public Dialog AskDialog(string answer1, string answer2, List<Dialog> answer2_dialogs)
	{
		Dialog dialog = new Dialog();
		dialog.Mode = "Ask";
		dialog.Answer1 = answer1;
		dialog.Answer2 = answer2;
		dialog.Answer2_Dialogs = answer2_dialogs;
		return dialog;
	}

	public Dialog PickUpItemDialog(string pickUpItemContent, GameObject pickUpItem)
	{
		Dialog dialog = new Dialog();
		dialog.Mode = "Pick";
		dialog.Content = pickUpItemContent;
		dialog.Item = pickUpItem;
		return dialog;
	}

	public void TellObjectDialogIsOver()
	{
		if (DialogOverEvent != null)
			DialogOverEvent(this, EventArgs.Empty);
	}

	public void EnterRange()
	{
		isPlayerInRange = true;
	}

	public void LeaveRange()
	{
		isPlayerInRange = false;
	}

	public bool IsPlayerInRange
	{
		get { return isPlayerInRange; }
	}

	public List<int> AskDialogAnswerList
	{
		get { return dialogManager.AskDialogAnswerList; }
	}

	public bool IsAutoPopUp
	{
		get { return isAutoPopUp; }
		set { isAutoPopUp = value; }
	}

	public List<Dialog> Dialogs
	{
		get { return dialogs; }
		set { dialogs = value; }
	}
}

