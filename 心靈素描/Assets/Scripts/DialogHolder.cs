using UnityEngine;
using System.Collections;

public class DialogHolder : MonoBehaviour {

	public string[] dialogLines;
	private DialogManager dMan;
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		dMan = FindObjectOfType<DialogManager> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		dMan.dialogLines = dialogLines;
		dMan.ShowBox(spriteRenderer.sprite);
	}
		
}
