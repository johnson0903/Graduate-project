using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class UmbrellaGirlPaint_LeftAI : MonoBehaviour {

	public Sprite umbrellaGirlWithBlood;
	public GameObject bloodUmbrella;

	private GameObject player;
	private DialogHolder dialogHolder;
	private static bool isKilled;

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
		if (!isKilled) {
			dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("一幅拿著傘的女人畫像"),
				dialogHolder.TalkDialog ("似乎在看著這邊的樣子..."),
				dialogHolder.AskDialog ("盯著看", "離開", new List<Dialog>{ dialogHolder.TalkDialog ("有點恐怖的感覺") }),
				dialogHolder.TalkDialog ("........"),
				dialogHolder.TalkDialog ("不給我進去的感覺"),
				dialogHolder.AskDialog ("拿走她的傘", "離開", new List<Dialog>{ dialogHolder.TalkDialog ("頭有點痛...") }),
				dialogHolder.TalkDialog ("......."),
				dialogHolder.TalkDialog ("他抓得好緊...."),
				dialogHolder.AskDialog ("用力", "放手", new List<Dialog>{ dialogHolder.TalkDialog ("頭有點痛...") }),
				dialogHolder.TalkDialog ("從圖裡面湧出了許多紅色的顏料"),
				dialogHolder.PickUpItemDialog ("獲得了 沾著顏料的雨傘", bloodUmbrella)
			};
		} else
			dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("一幅慘死女人的畫像"),
				dialogHolder.TalkDialog ("畫布上噴灑著許多紅色顏料...")
			};
	}


	void OnDialogOver(object sender, EventArgs e)
	{	
		if (dialogHolder.AskDialogAnswerList.Count > 2 && dialogHolder.AskDialogAnswerList [2] == 1) {
			isKilled = true;
			this.GetComponent<SpriteRenderer> ().sprite = umbrellaGirlWithBlood;
		}
	}

}
