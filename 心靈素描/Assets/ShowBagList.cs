using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShowBagList : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowBag() {
		if (this.isActiveAndEnabled == false)
			this.gameObject.SetActive (true);
		else
			this.gameObject.SetActive (false);
	}
}
