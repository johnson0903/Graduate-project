using UnityEngine;
using System.Collections;
using System;

public class DialogHolder : MonoBehaviour
{
	public event EventHandler DialogOverEvent;

	private PlayerController playerController;
	private DialogManager dialogManager;
	private Dialog[] dialogs;
	private bool isPlayerInRange;

	void Start()
	{
		dialogManager = FindObjectOfType<DialogManager>();
		playerController = FindObjectOfType<PlayerController>();
	}

	void OnMouseUp()
	{
		if (dialogs != null && isPlayerInRange && !dialogManager.IsDialogActive)
		{
			dialogManager.ShowBox(this.gameObject);
		}
	}

	public Dialog TalkDialog(string talkContent)
	{
		Dialog dialog = new Dialog();
		dialog.Mode = "Talk";
		dialog.Content = talkContent;
		return dialog;
	}

	public Dialog AskDialog(string askContent, string denyContent)
	{
		Dialog dialog = new Dialog();
		dialog.Mode = "Ask";
		dialog.Content = askContent;
		dialog.DenyContent = denyContent;
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

	public bool AskDialogAnswer
	{
		get { return dialogManager.AskDialogAnswer; }
	}

	public Dialog[] Dialogs
	{
		get { return dialogs; }
		set { dialogs = value; }
	}

}

