using UnityEngine;
using System.Collections;

public class DialogHolder : MonoBehaviour {

	public string dialog;
	private DialogManager dMan;

	// Use this for initialization
	void Start () {
		dMan = FindObjectOfType<DialogManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D other){
		Debug.Log ("fff");
		if (other.gameObject.name == "Player") {
			if(Input.GetMouseButtonUp(0)){
				dMan.ShowBox(dialog);
			}
		}
	}
}
