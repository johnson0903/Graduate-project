using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {
	
	private bool isPlayerInRange;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown()
	{
		if (isPlayerInRange)
		{
			if (Application.loadedLevel == 0)
				Application.LoadLevel (1);
			else
				Application.LoadLevel (0);
		}

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("PlayerRange"))
			isPlayerInRange = true;
		Debug.Log (isPlayerInRange.ToString ());
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag ("PlayerRange"))
			isPlayerInRange = false;
		//Debug.Log (isPlayerInRange.ToString ());
	}
}
