using UnityEngine;
using System.Collections;

public class DialogHolder : MonoBehaviour
{
	public string[] dialogLines;

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
		isDialogOver = false;
		if (isPlayerInRange && !dialogManager.IsDialogActive)
		{
			dialogManager.ShowBox (this.gameObject);
		}
	}

	public void EndTalk(){
		isDialogOver = true;
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
		
}

