using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Bedroom_BookcaseAI : MonoBehaviour {

	public GameObject knife;

	private DialogHolder dialogHolder;

	private static int bookCaseTalkCount;
	private static bool pencilTombPaintHasBeenTaken;

	// Use this for initialization
	void Start()
	{
		dialogHolder = this.GetComponent<DialogHolder>();
		this.GetComponent<DialogHolder> ().DialogOverEvent += OnDialogOver;
	}

	// Update is called once per frame
	void Update()
	{
		if (bookCaseTalkCount == 0) {
			dialogHolder.Dialogs = new List<Dialog> {
				dialogHolder.TalkDialog ("散發著木頭香味的書櫃"),
				dialogHolder.TalkDialog ("上面堆滿了許多書"),
				dialogHolder.AskDialog ("隨便拿起一本看看", "找尋其他地方", new List<Dialog> { dialogHolder.TalkDialog ("不要亂動好了") }),
				dialogHolder.TalkDialog ("《6上數學 點線面評量講義》"),
				dialogHolder.TalkDialog ("＂(一) 線對稱的意義＂"),
				dialogHolder.TalkDialog ("＂平面上的圖形，透過平移、旋轉與鏡射，可以得到與原圖形全等的圖形。給定一個平面圖形及一條對稱軸，可以透過線對稱這種鏡射概念，得到另一個全等的圖形。＂"),
				dialogHolder.PickUpItemDialog ("盡是一些看不懂的東西...", knife),
			};
		} else if (bookCaseTalkCount == 1) {
			dialogHolder.Dialogs = new List<Dialog> {
				dialogHolder.TalkDialog ("散發著木頭香味的書櫃"),
				dialogHolder.TalkDialog ("上面堆滿了許多書"),
				dialogHolder.AskDialog ("隨便拿起一本看看", "找尋其他地方", new List<Dialog> { dialogHolder.TalkDialog ("不要亂動好了") }),
				dialogHolder.TalkDialog ("《6上國語 新超群學習成就評量》"),
				dialogHolder.TalkDialog ("＂請完成下列成語：＂"),
				dialogHolder.TalkDialog ("＂自掘(    )墓 － 比喻自取滅亡，自毀前程＂"),
				dialogHolder.TalkDialog ("盡是一些看不懂的東西..."),
			};
		} else {
			dialogHolder.Dialogs = new List<Dialog> {
				dialogHolder.TalkDialog ("散發著木頭香味的書櫃"),
				dialogHolder.TalkDialog ("上面堆滿了許多書"),
				dialogHolder.AskDialog ("隨便拿起一本看看", "找尋其他地方", new List<Dialog> { dialogHolder.TalkDialog ("不要亂動好了") }),
				dialogHolder.TalkDialog ("發現了一本夾在教科書之中 顯得相當嬌小的日記"),
				dialogHolder.TalkDialog ("＂2016 / 9 / 3＂"),
				dialogHolder.TalkDialog ("＂今天又被媽媽罵了。＂"),
				dialogHolder.TalkDialog ("＂比你辛苦比你累的人多的事 你有什麼資格抱怨？ 被這樣訓斥了。＂"),
				dialogHolder.TalkDialog ("＂為什麼除了成績與才能，連痛苦也必須和他人比較呢？＂"),
				dialogHolder.TalkDialog ("＂想要逃離這個世界，活著到底有－＂"),
				dialogHolder.TalkDialog ("後面的部分被像是水一樣的東西弄糊了 看不清楚")
			};							
		}

	}
		
	void OnDialogOver(object sender, EventArgs e) {
		if (dialogHolder.AskDialogAnswerList.Count > 0 && dialogHolder.AskDialogAnswerList [0] == 1) {
			if (!pencilTombPaintHasBeenTaken) {
				if (bookCaseTalkCount == 2) {
					pencilTombPaintHasBeenTaken = true;
					bookCaseTalkCount = 0;
				} else
					bookCaseTalkCount++;	
			} else {
				if (bookCaseTalkCount == 1)
					bookCaseTalkCount = 0;
				else
					bookCaseTalkCount++;	
			}
		}
	}

}
