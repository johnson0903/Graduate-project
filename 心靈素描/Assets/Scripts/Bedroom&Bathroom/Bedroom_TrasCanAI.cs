using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Bedroom_TrasCanAI : MonoBehaviour {

	public GameObject bottle;

	private DialogHolder dialogHolder;
	private static bool isBottleTaken;

	// Use this for initialization
	void Start()
	{
		dialogHolder = this.GetComponent<DialogHolder>();
		this.GetComponent<DialogHolder>().DialogOverEvent += OnDialogOver;
	}

	// Update is called once per frame
	void Update()
	{
		if (!isBottleTaken) {
			dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("櫃子旁邊放了一個垃圾桶"),
				dialogHolder.TalkDialog ("裡面裝著許多撕碎的紙張"),
				dialogHolder.AskDialog ("檢查紙張", "檢查裡面", new List<Dialog> {
					dialogHolder.TalkDialog ("沙沙沙沙...."),
					dialogHolder.TalkDialog ("發現了一個透明堅硬的東西"),
					dialogHolder.PickUpItemDialog ("獲得了 空瓶", bottle)
				}),
				dialogHolder.TalkDialog ("＂第XX學年度 學期成績單＂"),
				dialogHolder.TalkDialog ("＂評語：上課缺乏專注力，與同學相處困難，請家長多加－＂"),
				dialogHolder.TalkDialog ("後面的部分被撕掉了...")
			};

		} else
			dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("櫃子旁邊放了一個垃圾桶"),
			dialogHolder.TalkDialog ("裡面裝著許多撕碎的紙張"),
			dialogHolder.AskDialog ("檢查紙張", "檢查裡面", new List<Dialog> {
				dialogHolder.TalkDialog ("裡面沒有其他東西了"),
			}),
			dialogHolder.TalkDialog ("＂第XX學年度 學期成績單＂"),
			dialogHolder.TalkDialog ("＂老師評語：上課缺乏專注力，與同學相處困難，請家長多加－＂"),
			dialogHolder.TalkDialog ("後面的部分被撕掉了...")
		};

	}

	void OnDialogOver(object sender, EventArgs e)
	{	
		if (!isBottleTaken && dialogHolder.AskDialogAnswerList[0] == 2)
			isBottleTaken = true;
	}
}
