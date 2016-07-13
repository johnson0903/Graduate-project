using UnityEngine;
using System.Collections;

public class Dialog : MonoBehaviour {

	private string mode;
	private string content;
	private GameObject item;

	public string Mode {
		get{ return mode; }
		set{ mode = value; }
	}
	public string Content {
		get{ return content; }
		set{ content = value; }
	}
	public GameObject Item {
		get{ return item; }
		set{ item = value; }
	}
}
