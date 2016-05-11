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

	// Update is called once per frame
	void Update ()
	{
	
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
		Debug.Log (isPlayerInRange.ToString ());
	}

	public void LeaveRange ()
	{
		isPlayerInRange = false;
		Debug.Log (isPlayerInRange.ToString ());
	}
}

