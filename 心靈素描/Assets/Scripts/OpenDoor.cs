using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {
	
	private bool isPlayerInRange;

	public Texture2D openDoorCursor;

	private Transform player;
	private bool isLocked = true;
	private static bool isGameStart;

	void Start () {
		Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
		player = FindObjectOfType<PlayerController> ().gameObject.transform;
		if (isGameStart) {	
			player.position = new Vector3 (this.transform.position.x, player.position.y, player.position.z);
		} else {
			isGameStart = true;
		}
	}

	// Update is called once per frame
	void Update () {
		if (player.GetComponent<PlayerInventory>().isSomethingInInventory("key"))
			isLocked = false;
	}

	void OnMouseEnter()
	{
		Cursor.SetCursor (openDoorCursor, Vector2.zero, CursorMode.Auto);
	}

	void OnMouseExit(){
		Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
	}

	void OnMouseUp()
	{
		if (isPlayerInRange && !isLocked)
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
