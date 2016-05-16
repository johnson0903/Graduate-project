using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown()
	{
		if (Application.loadedLevel == 0)
			Application.LoadLevel (1);
		else
			Application.LoadLevel (0);
	}


}
