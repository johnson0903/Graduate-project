using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class LivingRoom_SofaAI : MonoBehaviour {

	public GameObject TV;
	public GameObject oldPaper;

	private GameObject player;
	private DialogHolder dialogHolder;

	private static bool isPaperTaken;

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
		if (!isPaperTaken) {
			dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("藉由輪廓來判斷 這個應該是沙發"),
				dialogHolder.AskDialog ("沿著表面摸摸看", "檢查夾縫深處", new List<Dialog> {
					dialogHolder.TalkDialog ("發現了一張被夾在沙發縫隙的紙張"),
					dialogHolder.PickUpItemDialog ("獲得了 破舊書頁", oldPaper)
				}),
				dialogHolder.TalkDialog ("冰冰涼涼的皮革觸感"),
				dialogHolder.TalkDialog ("摸起來相當舒服")
			};
		} else
			dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("一張看似高級的皮革沙發"),
				dialogHolder.TalkDialog ("坐起來想必相當舒服")
			};
	}


	void OnDialogOver(object sender, EventArgs e)
	{	
		if (!isPaperTaken && dialogHolder.AskDialogAnswerList.Count > 0 && dialogHolder.AskDialogAnswerList[0] == 2) {
			isPaperTaken = true;
			TV.GetComponent<LivingRoom_TVAI> ().IsTVTurnedOn = true;
		}
	}
		
}
