using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class DialogHolder : MonoBehaviour
{
	public event EventHandler DialogOverEvent;
	public event EventHandler EventDialogEvent;
    public AudioClip[] audioClips;

    private DialogManager dialogManager;
	private SceneLoader sceneLoader;
	private List<Dialog> dialogs;
	private bool isPlayerInRange;
	private bool isAutoPopUp;

	void Start()
	{
		dialogManager = FindObjectOfType<DialogManager>();
		sceneLoader = FindObjectOfType<SceneLoader> ();
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (!isAutoPopUp && dialogs != null && !sceneLoader.IsLoading) {
				if (!dialogManager.IsDialogActive) {
					if (isPlayerInRange)
						dialogManager.StartDialog (this.gameObject);	
				} else
					dialogManager.ContinueDialog (this.gameObject);
			}
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (isAutoPopUp && dialogs != null && isPlayerInRange && !sceneLoader.IsLoading) {
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

	public Dialog PickUpItemDialog(string talkContent, GameObject pickUpItem)
	{
		Dialog dialog = new Dialog();
		dialog.Mode = "Pick";
		dialog.Content = talkContent;
		dialog.Item = pickUpItem;
		return dialog;
	}

	public Dialog PlaySoundDialog(string talkContent, int soundIndex, float volumn)
    {
        Dialog dialog = new Dialog();
        dialog.Mode = "PlaySound";
		dialog.Content = talkContent;
        dialog.Audio = audioClips[soundIndex];
		dialog.ClipVolumn = volumn;
        return dialog;
    }

	public Dialog EventDialog(string talkContent, int soundIndex, float volumn)
	{
		Dialog dialog = new Dialog();
		dialog.Mode = "Event";
		dialog.Content = talkContent;
		dialog.Audio = audioClips[soundIndex];
		dialog.ClipVolumn = volumn;
		return dialog;
	}

	public void TellObjectDialogIsOver()
	{
		if (DialogOverEvent != null)
			DialogOverEvent(this, EventArgs.Empty);
	}

	public void TellObjectEventDialogOccur()
	{
		if (EventDialogEvent != null)
			EventDialogEvent(this, EventArgs.Empty);
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

