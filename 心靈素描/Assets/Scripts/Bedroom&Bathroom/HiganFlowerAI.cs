using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class HiganFlowerAI : MonoBehaviour {

	public GameObject boxCutter;

	private GameObject player;
	private DialogHolder dialogHolder;

	private static int pencilTombTalkCount;

	// Use this for initialization
	void Start()
	{
		player = FindObjectOfType<PlayerController> ().gameObject;
		dialogHolder = this.GetComponent<DialogHolder> ();
		this.GetComponent<DialogHolder> ().DialogOverEvent += OnDialogOver;

		if (pencilTombTalkCount == 1)
			pencilTombTalkCount++;
	}

	// Update is called once per frame
	void Update()
	{
		if (pencilTombTalkCount == 0) {
			dialogHolder.Dialogs = new List<Dialog> {
				dialogHolder.TalkDialog ("一株帶有紅色花朵的植物長在土堆上"),
				dialogHolder.TalkDialog ("似乎還沒開花的樣子..."),
				dialogHolder.AskDialog ("摸摸看花", "摸摸看泥土", new List<Dialog> {
					dialogHolder.TalkDialog ("像是缺乏水份的關係 泥土相當乾燥"),
					dialogHolder.TalkDialog ("這樣下去花會枯死的吧")
				}),
				dialogHolder.TalkDialog ("花瓣摸起來相當細嫩"),
				dialogHolder.TalkDialog ("想必盛開的時候會很美吧")
			};
		} else if (pencilTombTalkCount == 2) {
			if (player.GetComponent<PlayerInventory> ().IsSomethingInInventory ("WaterBottle"))
				dialogHolder.Dialogs = new List<Dialog> {
					dialogHolder.TalkDialog ("一株帶有紅色花朵的植物長在土堆上"),
					dialogHolder.TalkDialog ("似乎比上次看得更加虛弱了..."),
					dialogHolder.AskDialog ("將水澆在泥土上", "離開", new List<Dialog> {
						dialogHolder.TalkDialog ("即將凋零的花 給人一種淒涼的感覺")
					}),
					dialogHolder.TalkDialog ("唰啦－"),
					dialogHolder.TalkDialog ("從瓶子中流出來的水 迅速地被泥土所吸收")
				};
			else
				dialogHolder.Dialogs = new List<Dialog> {
					dialogHolder.TalkDialog ("一株帶有紅色花朵的植物長在土堆上"),
					dialogHolder.TalkDialog ("似乎比上次看得更加虛弱了...")
				};
		} else if (pencilTombTalkCount == 3) {
			dialogHolder.Dialogs = new List<Dialog> {
				dialogHolder.TalkDialog ("土堆上盛開著一朵美麗的花"),
				dialogHolder.TalkDialog ("雖然不知道品種 但是相當美麗"),
				dialogHolder.TalkDialog ("在花瓣之間發現了一個發亮的東西"),
				dialogHolder.PickUpItemDialog ("獲得了 美工刀", boxCutter)
			};
		} else if (pencilTombTalkCount >= 4) {
			dialogHolder.Dialogs = new List<Dialog> {
				dialogHolder.TalkDialog ("土堆上盛開著一朵美麗的花"),
				dialogHolder.TalkDialog ("雖然不知道品種 但是相當美麗")
			};
		}
	}

	void OnDialogOver (object sender, EventArgs e)
	{
		if (pencilTombTalkCount == 0) {
			pencilTombTalkCount++;
		} else if (pencilTombTalkCount == 2) {
			if (player.GetComponent<PlayerInventory> ().IsSomethingInInventory ("WaterBottle") && dialogHolder.AskDialogAnswerList.Count > 0 && dialogHolder.AskDialogAnswerList [0] == 1) {
				player.GetComponent<PlayerInventory> ().DropItem ("WaterBottle");
				pencilTombTalkCount++;
			}
		} else if (pencilTombTalkCount == 3) {
			pencilTombTalkCount++;
		}
	}

}
