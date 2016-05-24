using UnityEngine;
using System.Collections;

public class DialogHolder : MonoBehaviour
{

	public string[] dialogLines;

	private DialogManager dialogManager;
	private GameObject player;
	private bool isPlayerInRange;

	private bool isTalking;


	// Use this for initialization
	void Start ()
	{
		dialogManager = FindObjectOfType<DialogManager> ();
		player = FindObjectOfType<PlayerController> ().gameObject;
	}

	void OnMouseUp ()
	{
		if (isPlayerInRange && !isTalking)
		{
			isTalking = true;
			dialogManager.ShowBox (this.GetComponent<SpriteRenderer> ().sprite, this.gameObject);
		}
	}

	public void EnterRange ()
	{
		isPlayerInRange = true;
		isTalking = false;
	}

	public void LeaveRange ()
	{
		isPlayerInRange = false;
		isTalking = false;
	}

	public bool IsPlayerInRange {
		get{ return isPlayerInRange; }
	}
		
		
}

