using UnityEngine;
using System.Collections;
using System;

public class PencilTombAI : MonoBehaviour {

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
				dialogHolder.TalkDialog ("一枝大大的鉛筆插在土堆上"),
				dialogHolder.TalkDialog ("像是墳墓一樣..."),
				dialogHolder.AskDialog ("挖挖看", "摸摸看", new Dialog[] { dialogHolder.TalkDialog ("冰冰的觸感 讓人很不舒服") }),
				dialogHolder.TalkDialog ("沙沙沙沙....."),
				dialogHolder.TalkDialog ("挖到了一個硬硬的東西"),
				dialogHolder.PickUpItemDialog ("獲得了 美工刀", boxCutter)
			};
		} else if (isBoxCutterTaken) {
			dialogHolder.Dialogs = new Dialog[] { 
				dialogHolder.TalkDialog ("散亂的土堆散在草地上"),
				dialogHolder.TalkDialog ("有點淒涼的樣子...")
			};
		}
	}

	void OnDialogOver(object sender, EventArgs e) {
		if (!isBoxCutterTaken && dialogHolder.AskDialogAnswer == 1)
			isBoxCutterTaken = true;
	}
}
