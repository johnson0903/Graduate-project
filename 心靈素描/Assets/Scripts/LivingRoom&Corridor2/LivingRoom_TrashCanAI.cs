using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class LivingRoom_TrashCanAI : MonoBehaviour {

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
				dialogHolder.TalkDialog ("沙發旁邊放了一個鐵製的垃圾桶"),
				dialogHolder.AskDialog ("檢查內部", "離開", new List<Dialog> {
					dialogHolder.TalkDialog ("找找其他地方吧"),
				}),
				dialogHolder.TalkDialog ("裡面似乎有一疊奇怪的東西"),
				dialogHolder.PickUpItemDialog ("獲得了 快樂的面具", happyMask),
				dialogHolder.PickUpItemDialog ("獲得了 生氣的面具", angryMask),
				dialogHolder.PickUpItemDialog ("獲得了 悲傷的面具", sadMask),
				dialogHolder.PickUpItemDialog ("獲得了 無表情的面具", boringMask)
			};
		}
		else
			dialogHolder.Dialogs = new List<Dialog> { 
			dialogHolder.TalkDialog ("沙發旁邊放了一個鐵製的垃圾桶"),
			dialogHolder.TalkDialog ("除了剛剛的面具之外 裡面已經沒有東西了")
		};
	}

	void OnDialogOver(object sender, EventArgs e)
	{
		if (!areFourMasksTaken && dialogHolder.AskDialogAnswerList.Count > 0 && dialogHolder.AskDialogAnswerList[0] == 1) 
			areFourMasksTaken = true;
	}
		
}
