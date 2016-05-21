using UnityEngine;
using System.Collections;

public class DialogHolder : MonoBehaviour
{

	public string[] dialogLines;

	private DialogManager dialogManager;
	private GameObject player;
	private bool isPlayerInRange;


	// Use this for initialization
	void Start ()
	{
		dialogManager = FindObjectOfType<DialogManager> ();
		player = FindObjectOfType<PlayerController> ().gameObject;
	}

	void OnMouseDown ()
	{
		if (isPlayerInRange)
		{
			dialogManager.ShowBox (this.GetComponent<SpriteRenderer> ().sprite, this.gameObject);
		}
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
		
		
}

