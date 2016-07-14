using UnityEngine;
using System.Collections;

public class DialogHolder : MonoBehaviour
{
	private Dialog[] dialogs;
	private GameObject player;
	private DialogManager dialogManager;
	private bool isPlayerInRange;
	private bool isDialogOver;

	// Use this for initialization
	void Start()
	{
		player = FindObjectOfType<PlayerController>().gameObject;
		dialogManager = FindObjectOfType<DialogManager>();
	}

	void OnMouseUp()
	{
		isDialogOver = false;

		if (isPlayerInRange && !dialogManager.IsDialogActive && !isDialogOver)
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

	public void EndTalk()
	{
		isDialogOver = true;
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

	public bool IsDialogOver
	{
		get { return isDialogOver; }
		set { isDialogOver = value; }
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

