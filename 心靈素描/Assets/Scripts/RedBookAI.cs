using UnityEngine;
using System.Collections;
using System;

public class RedBookAI : MonoBehaviour
{
	public GameObject boxCutter;

	private GameObject player;
	private DialogHolder dialogHolder;
	private static bool isBoxCutterTaken;

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
		if (!isBoxCutterTaken) {
			dialogHolder.Dialogs = new Dialog[] {
				dialogHolder.TalkDialog ("只有這本書是紅色的"),
				dialogHolder.TalkDialog ("後面好像有一根東西"),
				dialogHolder.PickUpItemDialog ("獲得了 美工刀", boxCutter)
			};
		} else if (isBoxCutterTaken) {
			dialogHolder.Dialogs = new Dialog[] { dialogHolder.TalkDialog ("這邊已經沒有東西了") };
		}
	}

	void OnDialogOver(object sender, EventArgs e) {
		isBoxCutterTaken = true;
	}
}
