using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {
	public string[] dialogLines;
	private DialogManager dMan;
	private SpriteRenderer spriteRenderer;

	void Start(){
		dMan = FindObjectOfType<DialogManager> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	public void ShowDialog(){
		dMan.dialogLines = dialogLines;
		dMan.ShowBox(spriteRenderer.sprite);
	}
}
