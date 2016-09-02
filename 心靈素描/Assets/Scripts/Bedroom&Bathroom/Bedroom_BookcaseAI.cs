using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Bedroom_BookcaseAI : MonoBehaviour {

	public GameObject pencilTombPaint;

	private GameObject player;
	private DialogHolder dialogHolder;

	private static int bookCaseTalkCount;
	private static bool pencilTombPaintHasBeenTaken;

	// Use this for initialization
	void Start()
	{
		player = FindObjectOfType<PlayerController>().gameObject;
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
				dialogHolder.TalkDialog ("盡是一些看不懂的東西..."),
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
				dialogHolder.TalkDialog ("《藝術與人文 6上》"),
				dialogHolder.TalkDialog ("＂探索與創作＂"),
				dialogHolder.TalkDialog ("＂使每位學生能自我探索，覺知環境與個人的關係，運用媒材與形式，從事藝術創作，以豐富生活與心靈。＂"),
				dialogHolder.TalkDialog ("發現書裡面夾了一張紙"),
				dialogHolder.PickUpItemDialog ("獲得了 奇怪的塗鴉", pencilTombPaint)
			};							
		}

	}


	void OnDialogOver(object sender, EventArgs e) {
		if (dialogHolder.AskDialogAnswerList [0] == 1) {
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
