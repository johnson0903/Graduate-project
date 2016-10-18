using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dialog
{

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

	public List<Dialog> Answer2_Dialogs
	{
		get;
		set;
	}

    public AudioClip Audio
    {
        get;
        set;
    }

	public float ClipVolumn
	{
		get;
		set;
	}

	public Sprite Image
	{
		get;
		set;
	}
}
