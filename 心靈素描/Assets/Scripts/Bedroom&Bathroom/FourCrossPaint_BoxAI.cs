using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class FourCrossPaint_BoxAI : MonoBehaviour {
	
	public GameObject happyMask;
	public GameObject angryMask;
	public GameObject sadMask;
	public GameObject boringMask;

	private GameObject player;
	private DialogHolder dialogHolder;

	private static bool areFourMasksTaken;

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
		if (!areFourMasksTaken) {
			dialogHolder.Dialogs = new List<Dialog> { 
				dialogHolder.TalkDialog ("地上放著一個箱子"),
				dialogHolder.TalkDialog ("裡面放了四個不同樣子的面具"),
				dialogHolder.PickUpItemDialog ("獲得了 快樂的面具", happyMask),
				dialogHolder.PickUpItemDialog ("獲得了 生氣的面具", angryMask),
				dialogHolder.PickUpItemDialog ("獲得了 悲傷的面具", sadMask),
				dialogHolder.PickUpItemDialog ("獲得了 無表情的面具", boringMask),
				dialogHolder.TalkDialog ("內側還貼了一張紙條"),
				dialogHolder.TalkDialog ("＂莫把憤怒之人說的話當真。＂")
			};
		}
		else
			dialogHolder.Dialogs = new List<Dialog> { 
			dialogHolder.TalkDialog ("裡面已經沒有東西了"),
			dialogHolder.TalkDialog ("箱子的內側還貼了一張紙條"),
			dialogHolder.TalkDialog ("＂莫把憤怒之人說的話當真。＂")
		};
	}

	void OnDialogOver(object sender, EventArgs e)
	{
		if (!areFourMasksTaken) 
			areFourMasksTaken = true;
	}

	public bool AreFourMasksTaken {
		get{ return areFourMasksTaken; }
	}
}
