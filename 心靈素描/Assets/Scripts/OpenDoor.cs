using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

	public Texture2D openDoorCursor;

	private Transform player;
	private static bool isGameStart;

	void Start () {
		Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
		if (isGameStart) {
			player = FindObjectOfType<PlayerController> ().gameObject.transform;
			player.position = new Vector3 (this.transform.position.x, player.position.y, player.position.z);
		} else {
			isGameStart = true;
		}
	}

	// Update is called once per frame
	void Update () {
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
		if (Application.loadedLevel == 0)
			Application.LoadLevel (1);
		else
			Application.LoadLevel (0);
	}


}
