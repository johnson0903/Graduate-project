using UnityEngine;
using System.Collections;
using System;


public class Bedroom_PillowAI : MonoBehaviour {

	public GameObject key;
	public GameObject pencilTombPaint;

	private GameObject player;
	private DialogHolder dialogHolder;
	private static bool isPillowKeyTaken;

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
		//如果枕頭裡的鑰匙還沒被拿走
		if (!isPillowKeyTaken) {
			if (player.GetComponent<PlayerInventory> ().isSomethingInInventory ("BoxCutter")) {     //如果身上有美工刀
				dialogHolder.Dialogs = new Dialog[] { dialogHolder.TalkDialog ("軟綿綿的枕頭"),
					dialogHolder.TalkDialog ("感覺躺起來很舒服"),
					dialogHolder.AskDialog ("用美工刀劃開枕頭", "把枕頭翻開看看", new Dialog[] {
						dialogHolder.TalkDialog ("底下已經什麼都沒有了")
					}),
					dialogHolder.TalkDialog ("沙沙沙沙沙"),
					dialogHolder.PickUpItemDialog ("獲得了 大門的鑰匙", key)
				};
			} else    //如果身上沒有美工刀
				dialogHolder.Dialogs = new Dialog[] { dialogHolder.TalkDialog ("軟綿綿的枕頭"),
					dialogHolder.TalkDialog ("感覺躺起來很舒服"),
					dialogHolder.AskDialog ("把枕頭翻開看看", "躺躺看", new Dialog[] {
						dialogHolder.TalkDialog ("......"),
						dialogHolder.TalkDialog ("貪睡鬼")
					}),
					dialogHolder.TalkDialog ("枕頭下夾著一張紙"),
					dialogHolder.TalkDialog ("上面好像畫著什麼"),
				dialogHolder.PickUpItemDialog ("獲得了 奇怪的塗鴉", pencilTombPaint)
				};
		} else    //枕頭的鑰匙被拿了
			dialogHolder.Dialogs = new Dialog[] { dialogHolder.TalkDialog ("撕碎的枕頭散落在床上"), dialogHolder.TalkDialog ("瞧你都幹了什麼") };
	}

	void OnDialogOver(object sender, EventArgs e)
	{	
		
	}
}
