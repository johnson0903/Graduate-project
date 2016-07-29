using UnityEngine;
using System.Collections;

public class Dialog
{

	private GameObject item;

	public string Mode
	{
		get;
		set;
	}

	public string Content
	{
		get;
		set;
	}

	public GameObject Item
	{
		get;
		set;
	}

	public string Answer1
	{
		get;
		set;
	}

	public string Answer2
	{
		get;
		set;
	}

	public Dialog[] Answer2_Dialogs
	{
		get;
		set;
	}
}
