using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Bedroom_ClockAI : MonoBehaviour {

	private GameObject player;
	private DialogHolder dialogHolder;

	// Use this for initialization
	void Start()
	{
		player = FindObjectOfType<PlayerController> ().gameObject;
		dialogHolder = this.GetComponent<DialogHolder> ();
		this.GetComponent<DialogHolder> ().DialogOverEvent += OnDialogOver;
	}

	// Update is called once per frame
	void Update()
	{
		dialogHolder.Dialogs = new List<Dialog> { 
			dialogHolder.TalkDialog ("古老的時鐘 發出規律的滴答滴答聲"),
			dialogHolder.TalkDialog ("上面顯示著三點鐘")
		};
	}

	void OnDialogOver(object sender, EventArgs e)
	{	
		
	}
}
