using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class HiganFlowerAI : MonoBehaviour {

	public GameObject boxCutter;
	public GameObject oldBackGround;
	public Sprite newBackGroundImage;

	private GameObject player;
	private DialogHolder dialogHolder;

	private static int higanFlowerTalkCount;

	// Use this for initialization
	void Start()
	{
		player = FindObjectOfType<PlayerController> ().gameObject;
		dialogHolder = this.GetComponent<DialogHolder> ();
		this.GetComponent<DialogHolder> ().DialogOverEvent += OnDialogOver;
		this.GetComponent<DialogHolder> ().EventDialogEvent += OnEventDialogOccur;
		if (higanFlowerTalkCount >= 1)
			oldBackGround.GetComponent<SpriteRenderer> ().sprite = newBackGroundImage;
	}

	// Update is called once per frame
	void Update()
	{
		if (higanFlowerTalkCount == 0) {
			if (player.GetComponent<PlayerInventory> ().IsSomethingInInventory ("WaterBottle"))
				dialogHolder.Dialogs = new List<Dialog> {
					dialogHolder.TalkDialog ("一株帶有紅色花朵的植物長在土堆上"),
					dialogHolder.TalkDialog ("似乎還沒開花的樣子..."),
					dialogHolder.AskDialog ("將水澆在泥土上", "離開", new List<Dialog> {
						dialogHolder.TalkDialog ("花朵看起來相當虛弱似的")
					}),
					dialogHolder.PlaySoundDialog ("唰啦－", 0, .5f),
					dialogHolder.TalkDialog ("從瓶子中流出來的水 迅速地被泥土所吸收"),
					dialogHolder.EventDialog ("原本閉合著的花瓣 漸漸地打開了", false, 0, .5f)
				};
			else
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
		} else if (higanFlowerTalkCount == 1) {
			dialogHolder.Dialogs = new List<Dialog> {
				dialogHolder.TalkDialog ("土堆上盛開著一朵美麗的花"),
				dialogHolder.TalkDialog ("雖然不知道品種 但是十分美麗"),
				dialogHolder.TalkDialog ("在花瓣之間發現了一個發亮的東西"),
				dialogHolder.PickUpItemDialog ("獲得了 美工刀", boxCutter)
			};
		} else if (higanFlowerTalkCount >= 2) {
			dialogHolder.Dialogs = new List<Dialog> {
				dialogHolder.TalkDialog ("土堆上盛開著一朵美麗的花"),
				dialogHolder.TalkDialog ("雖然不知道品種 但是十分美麗")
			};
		}
	}

	void OnDialogOver (object sender, EventArgs e)
	{
		if (higanFlowerTalkCount == 0) {
			if (player.GetComponent<PlayerInventory> ().IsSomethingInInventory ("WaterBottle") && dialogHolder.AskDialogAnswerList.Count > 0 && dialogHolder.AskDialogAnswerList [0] == 1) {
				player.GetComponent<PlayerInventory> ().DropItem ("WaterBottle");
				higanFlowerTalkCount++;

			}
		} else if (higanFlowerTalkCount == 1) {
			higanFlowerTalkCount++;
		}
	}

	void OnEventDialogOccur(object sender, EventArgs e)
	{	
		oldBackGround.GetComponent<SpriteRenderer> ().sprite = newBackGroundImage;
	}

}
