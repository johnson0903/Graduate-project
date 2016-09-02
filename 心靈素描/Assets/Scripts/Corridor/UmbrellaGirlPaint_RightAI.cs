using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class UmbrellaGirlPaint_RightAI : MonoBehaviour {

	public Sprite umbrellaGirlWithUmbrella;
	public Sprite umbrellaGirlWithBlood;
	public GameObject bloodUmbrella;

	private GameObject player;
	private DialogHolder dialogHolder;
	private static bool isBloodUmbrellaGotten;
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
			if (!isBloodUmbrellaGotten) {
				if (player.GetComponent<PlayerInventory> ().IsSomethingInInventory ("BloodUmbrella")) {
					dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("一幅畫著女人的畫像"),
						dialogHolder.TalkDialog ("哀戚的眼神似乎在期待著些什麼..."),
						dialogHolder.AskDialog ("給他雨傘", "離開", new List<Dialog>{ dialogHolder.TalkDialog ("有點恐怖的感覺") }),
						dialogHolder.TalkDialog ("將雨傘給了女人"),
						dialogHolder.TalkDialog ("畫中的女人浮起了一抹微笑")
					};
				} else
					dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("一幅畫著女人的畫像"),
						dialogHolder.TalkDialog ("哀戚的眼神似乎在期待著些什麼...")
					};
				
			} else
				dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("一幅拿著傘的女人畫像"),
					dialogHolder.AskDialog ("拿走她的傘", "離開", new List<Dialog>{ dialogHolder.TalkDialog ("頭有點痛...") }),
					dialogHolder.TalkDialog ("......."),
					dialogHolder.TalkDialog ("畫中的女人突然拿起傘 劃破了自己的喉嚨"),
					dialogHolder.TalkDialog ("嘶....嘶嘶....."),
					dialogHolder.TalkDialog ("從圖裡面湧出了許多紅色的顏料"),
					dialogHolder.TalkDialog ("雨傘從女人鬆開的右手中掉了下來"),
					dialogHolder.PickUpItemDialog ("獲得了 沾著顏料的雨傘", bloodUmbrella)
				};
		} else
			dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("一幅慘死女人的畫像"),
				dialogHolder.TalkDialog ("畫布上噴灑著許多紅色顏料...")
			};

	}

	void OnDialogOver(object sender, EventArgs e)
	{	
		
		if (!isBloodUmbrellaGotten) {
			if (player.GetComponent<PlayerInventory> ().IsSomethingInInventory ("BloodUmbrella")) {
				if (dialogHolder.AskDialogAnswerList.Count > 0 && dialogHolder.AskDialogAnswerList [0] == 1) {
					isBloodUmbrellaGotten = true;
					player.GetComponent<PlayerInventory> ().DropItem ("BloodUmbrella");
					this.GetComponent<SpriteRenderer> ().sprite = umbrellaGirlWithUmbrella;
				}
			}
		} else {
			if (dialogHolder.AskDialogAnswerList.Count > 0 && dialogHolder.AskDialogAnswerList [0] == 1) {
				isKilled = true;
				this.GetComponent<SpriteRenderer> ().sprite = umbrellaGirlWithBlood;
			}
		}
	
	}
}
