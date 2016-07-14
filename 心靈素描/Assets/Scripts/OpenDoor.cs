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

	void OnMouseEnter()
	{
		Cursor.SetCursor (openDoorCursor, Vector2.zero, CursorMode.Auto);
	}

	void OnMouseExit(){
		Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
	}

}
