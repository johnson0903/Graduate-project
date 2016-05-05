using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

	private DialogManager dMan;

	void Start(){
		dMan = FindObjectOfType<DialogManager> ();
	}
	public void ShowDialog(){
		dMan.ShowBox("這是草莓嗎?為什麼這裡會有草莓....看上去好像很好吃");
	}
}
