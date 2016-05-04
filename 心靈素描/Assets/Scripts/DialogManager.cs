using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

	public GameObject dBox;
	public Text dText;

	public bool dialogActive;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (dialogActive && Input.GetKeyDown(KeyCode.Space)) {
			dBox.SetActive(false);
			dialogActive = false;
		}
	}

	public void ShowBox(string dialog){
		dialogActive = true;
		dBox.SetActive (true);
		dText.text = dialog;
	}
}
