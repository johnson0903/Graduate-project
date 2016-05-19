using UnityEngine;
using System.Collections;

public class DialogHolder : MonoBehaviour
{

	public string[] dialogLines;
	private DialogManager dMan;
	private SpriteRenderer spriteRenderer;
	private bool isPlayerInRange;

	// Use this for initialization
	void Start ()
	{
		dMan = FindObjectOfType<DialogManager> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	void OnMouseDown ()
	{
		if (isPlayerInRange)
		{
			dMan.ShowBox (spriteRenderer.sprite, this.gameObject);
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
}

