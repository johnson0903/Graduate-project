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
	void Start ()
	{
		player = FindObjectOfType<PlayerController> ().gameObject;
		dialogManager = FindObjectOfType<DialogManager> ();
	}

	void OnMouseUp ()
	{
		if (isPlayerInRange && !dialogManager.IsDialogActive)
		{
			dialogManager.ShowBox (this.gameObject);
		}
	}

	public Dialog TalkDialog(string talkContent){
		Dialog dialog = new Dialog ();
		dialog.Mode = "Talk";
		dialog.Content = talkContent;
		dialog.Item = null;
		return dialog;
	}
	public Dialog AskDialog(string askContent){
		Dialog dialog = new Dialog ();
		dialog.Mode = "Talk";
		dialog.Content = askContent;
		dialog.Item = null;
		return dialog;
	}
	public Dialog PickUpItemDialog(string pickUpItemContent, GameObject pickUpItem){
		Dialog dialog = new Dialog ();
		dialog.Mode = "Talk";
		dialog.Content = pickUpItemContent;
		dialog.Item = pickUpItem;
		return dialog;
	}


	public void EndTalk(){
		isDialogOver = true;
	}

	public void AllisDone(){
		isDialogOver = false;
	}

	public void EnterRange ()
	{
		isPlayerInRange = true;
	}

	public void LeaveRange ()
	{
		isPlayerInRange = false;
	}

	public bool IsPlayerInRange {
		get{ return isPlayerInRange; }
	}

	public bool IsDialogOver {
		get{ return isDialogOver; }
	}

	public Dialog[] Dialogs {
		get{ return dialogs; }
		set{ dialogs = value; }
	}
		
}

