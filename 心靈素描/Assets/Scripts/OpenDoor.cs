using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {
	
	public Texture2D openDoorCursor;

	private Transform player;
	private bool isLocked = true;
	private static bool isGameStart;
	private bool isPlayerInRange;

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
		if (player.GetComponent<PlayerInventory>().isSomethingInInventory("Key"))
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
		Debug.Log (this.GetComponent<DialogHolder>().IsPlayerInRange);
		if (this.GetComponent<DialogHolder>().IsPlayerInRange && !isLocked)
		{
			if (Application.loadedLevel == 0)
				Application.LoadLevel (1);
			else
				Application.LoadLevel (0);
		}
	}

	public void EnterRange ()
	{
		isPlayerInRange = true;
		Debug.Log (isPlayerInRange.ToString ());
	}

	public void LeaveRange ()
	{
		isPlayerInRange = false;
		Debug.Log (isPlayerInRange.ToString ());
	}


}
