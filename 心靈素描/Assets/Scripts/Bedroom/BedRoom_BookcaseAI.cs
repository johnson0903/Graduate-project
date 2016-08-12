using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class BedRoom_BookcaseAI : MonoBehaviour {

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
				dialogHolder.AskDialog ("拿起一本看看", "找尋其他地方", new List<Dialog> { dialogHolder.TalkDialog ("不要亂動好了") }),
				dialogHolder.TalkDialog ("《6上數學 點線面評量講義》"),
				dialogHolder.TalkDialog ("＂乘法和除法 - 乘法的意義和運算＂"),
				dialogHolder.TalkDialog ("＂乘法（英語：Multiplication），加法的連續運算，同一數的若干次連加，其運算結果稱為積＂"),
				dialogHolder.TalkDialog ("盡是一些看不懂的東西..."),
			};
		} else if (bookCaseTalkCount == 1) {
			dialogHolder.Dialogs = new List<Dialog> {
				dialogHolder.TalkDialog ("散發著木頭香味的書櫃"),
				dialogHolder.TalkDialog ("上面堆滿了許多書"),
				dialogHolder.AskDialog ("拿起一本看看", "找尋其他地方", new List<Dialog> { dialogHolder.TalkDialog ("不要亂動好了") }),
				dialogHolder.TalkDialog ("《6上國語 新超群學習成就評量》"),
				dialogHolder.TalkDialog ("＂請完成下列成語：＂"),
				dialogHolder.TalkDialog ("＂自掘(  )墓 － 比喻自取滅亡，自毀前程＂"),
				dialogHolder.TalkDialog ("盡是一些看不懂的東西..."),
			};
		} else {
			dialogHolder.Dialogs = new List<Dialog> {
				dialogHolder.TalkDialog ("散發著木頭香味的書櫃"),
				dialogHolder.TalkDialog ("上面堆滿了許多書"),
				dialogHolder.AskDialog ("拿起一本看看", "找尋其他地方", new List<Dialog> { dialogHolder.TalkDialog ("不要亂動好了") }),
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
