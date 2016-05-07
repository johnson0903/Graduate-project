using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {
	public string dialog;
	private DialogManager dMan;
	private SpriteRenderer spriteRenderer;

	void Start(){
		dMan = FindObjectOfType<DialogManager> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	public void ShowDialog(){
		dMan.ShowBox(dialog, spriteRenderer.sprite);
	}
}
