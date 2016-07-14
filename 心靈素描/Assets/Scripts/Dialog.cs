using UnityEngine;
using System.Collections;

public class Dialog {

	private string mode;
	private string content;
	private GameObject item;
	private string denyContent;

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

	public string DenyContent {
		get{ return denyContent; }
		set{ denyContent = value; }
	}
}
