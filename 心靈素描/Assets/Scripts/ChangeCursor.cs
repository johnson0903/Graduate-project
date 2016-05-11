using UnityEngine;
using System.Collections;

public class ChangeCursor : MonoBehaviour
{
	public Texture2D canGet;
	public Texture2D grab;
	public Vector2 hotSpot = Vector2.zero;
	public CursorMode cursorMode = CursorMode.Auto;

	void OnMouseEnter()
	{
		Cursor.SetCursor (canGet, hotSpot, cursorMode);
	}

	void OnMouseExit(){
		Cursor.SetCursor (null, Vector2.zero, cursorMode);
	}

	void OnMouseDown(){
		Cursor.SetCursor (grab, Vector2.zero, cursorMode);
	}

	void OnMouseUp(){
		Cursor.SetCursor (canGet, Vector2.zero, cursorMode);
	}
}
