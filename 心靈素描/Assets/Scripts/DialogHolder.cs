using UnityEngine;
using System.Collections;
using System;

public class DialogHolder : MonoBehaviour
{
	public event EventHandler DialogOverEvent;

	private DialogManager dialogManager;
	private Dialog[] dialogs;
	private bool isPlayerInRange;

	void Start()
	{
		dialogManager = FindObjectOfType<DialogManager>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			if (dialogs != null && isPlayerInRange)
				dialogManager.ContinueDialog(this.gameObject);
	}

	public Dialog TalkDialog(string talkContent)
	{
		Dialog dialog = new Dialog();
		dialog.Mode = "Talk";
		dialog.Content = talkContent;
		return dialog;
	}

	public Dialog AskDialog(string answer1, string answer2, Dialog[] answer2_dialogs)
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
		Debug.Log ("123");
	}

	public bool IsPlayerInRange
	{
		get { return isPlayerInRange; }
	}

	public int AskDialogAnswer
	{
		get { return dialogManager.AskDialogAnswer; }
	}

	public Dialog[] Dialogs
	{
		get { return dialogs; }
		set { dialogs = value; }
	}
}

