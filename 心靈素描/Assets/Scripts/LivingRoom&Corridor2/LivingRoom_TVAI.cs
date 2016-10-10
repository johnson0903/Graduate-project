using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class LivingRoom_TVAI : MonoBehaviour {

	private GameObject player;
	private DialogHolder dialogHolder;

	// Use this for initialization
	void Start()
	{
		player = FindObjectOfType<PlayerController>().gameObject;
		dialogHolder = this.GetComponent<DialogHolder>();
		this.GetComponent<DialogHolder>().DialogOverEvent += OnDialogOver;
	}

	// Update is called once per frame
	void Update()
	{
		if(IsTVTurnedOn)
		dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("電視的螢幕上面閃爍著紅色的畫面"),
			dialogHolder.TalkDialog ("按電源鍵也沒有任何反應...")
		};
		else
			dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("一台深灰色的電視"),
			dialogHolder.TalkDialog ("按電源鍵也沒有任何反應...")
		};
	}


	void OnDialogOver(object sender, EventArgs e)
	{	
		
	}

	public bool IsTVTurnedOn {
		get {
			if (this.transform.FindChild ("ScreenLight1").gameObject.activeSelf && this.transform.FindChild ("ScreenLight2").gameObject.activeSelf)
				return true;
			else
				return false;
		}
		set { 
			this.transform.FindChild ("ScreenLight1").gameObject.SetActive (value);
			this.transform.FindChild ("ScreenLight2").gameObject.SetActive (value);
		}
	
	}
}
