using UnityEngine;
using System.Collections;
using System;

public class PillowAI : MonoBehaviour
{

	public GameObject key;

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
		if (!isPillowKeyTaken)
		{
			if (player.GetComponent<PlayerInventory>().isSomethingInInventory("BoxCutter"))     //如果身上有美工刀
			{
				dialogHolder.Dialogs = new Dialog[] { dialogHolder.TalkDialog ("軟綿綿的枕頭"),
												      dialogHolder.TalkDialog ("但裡面好像有一個硬硬的東西"),
					                                  dialogHolder.TalkDialog("要用美工刀劃開枕頭看看嗎"),
													  dialogHolder.AskDialog("不管了拿起來吧", "不要好了感覺好危險", new Dialog[]{dialogHolder.TalkDialog("怕怕ㄉ"), dialogHolder.TalkDialog("怕怕ㄉ2") }),
													  dialogHolder.PickUpItemDialog("獲得了 大門的鑰匙", key) };
			}
			else   //如果身上沒有美工刀
			{
				dialogHolder.Dialogs = new Dialog[] {
					dialogHolder.TalkDialog ("軟綿綿的枕頭"),
					dialogHolder.TalkDialog ("但裡面好像有一個硬硬的東西")
				};
			}
		}
		else    //枕頭的鑰匙被拿了
		{
			dialogHolder.Dialogs = new Dialog[] { dialogHolder.TalkDialog("撕碎的枕頭散落在床上"), dialogHolder.TalkDialog("瞧你都幹了什麼") };
		}
	}

	void OnDialogOver(object sender, EventArgs e)
	{	
		if (!isPillowKeyTaken && dialogHolder.AskDialogAnswer == 1)
			isPillowKeyTaken = true;
	}

}
