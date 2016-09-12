using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class GoBackPaintAI : MonoBehaviour {

	public GameObject clock;

	private const int SPILLING_SFX = 0;
	private GameObject player;
	private DialogHolder dialogHolder;

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
		dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("一幅全黑的畫 中央畫著大大的綠色三角形"),
			dialogHolder.AskDialog ("摸摸看", "離開", new List<Dialog>{ dialogHolder.TalkDialog ("感覺這圖案在哪裡看過...") }),
			dialogHolder.TalkDialog ("你摸了位於中央的綠色三角形"),
			dialogHolder.PlaySoundDialog ("噗啾－", SPILLING_SFX),
			dialogHolder.TalkDialog ("從畫裡發出了滑稽的聲音")
		};
	}

	void OnDialogOver(object sender, EventArgs e)
	{	
		if (dialogHolder.AskDialogAnswerList.Count > 0 && dialogHolder.AskDialogAnswerList [0] == 1) {
			clock.GetComponent<Corridor_ClockAI> ().AdjusyTime (-1);
		}
	}
}
