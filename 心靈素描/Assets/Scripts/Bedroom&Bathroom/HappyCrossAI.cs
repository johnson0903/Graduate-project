using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class HappyCrossAI : MonoBehaviour {
	
	public GameObject happyMask;
	public GameObject angryMask;
	public GameObject sadMask;
	public GameObject boringMask;

	private GameObject currentMask;
	private GameObject player;
	private DialogHolder dialogHolder;

	// Use this for initialization
	void Start()
	{
		player = FindObjectOfType<PlayerController> ().gameObject;
		dialogHolder = this.GetComponent<DialogHolder> ();
		this.GetComponent<DialogHolder> ().DialogOverEvent += OnDialogOver;
	}

	// Update is called once per frame
	void Update()
	{
		if (currentMask == null) {
			dialogHolder.Dialogs = new List<Dialog> { 
				dialogHolder.TalkDialog ("在地上聳立著黑色的十字架"),
				dialogHolder.TalkDialog ("上面好像有刻字..."),
				dialogHolder.TalkDialog ("＂我受不了身旁有愛生氣的人，包括我自己。＂"),
				dialogHolder.TalkDialog ("十字架中間有一個像是可以放進什麼東西的凹槽"),
				dialogHolder.TalkDialog ("要放上哪一種面具呢？"),
				dialogHolder.AskDialog ("快樂的面具", "其他", new List<Dialog> {
					dialogHolder.AskDialog ("生氣的面具", "其他", new List<Dialog> {
						dialogHolder.AskDialog ("悲傷的面具", "其他", new List<Dialog> {
							dialogHolder.AskDialog ("無表情的面具", "離開", new List<Dialog> {
								dialogHolder.TalkDialog ("再想想看好了....")
							}),
							dialogHolder.TalkDialog ("放上了 無表情的面具"),
						}),
						dialogHolder.TalkDialog ("放上了 悲傷的面具"),
					}),
					dialogHolder.TalkDialog ("放上了 生氣的面具"),
				}),
				dialogHolder.TalkDialog ("放上了 快樂的面具")
			};
		} else
			dialogHolder.Dialogs = new List<Dialog> { 
			dialogHolder.TalkDialog ("在地上聳立著黑色的十字架"),
			dialogHolder.TalkDialog ("上面好像有刻字..."),
			dialogHolder.TalkDialog ("＂我受不了身旁有愛生氣的人，包括我自己。＂"),
			dialogHolder.TalkDialog ("十字架中間放著 " + currentMask.GetComponent<ItemData> ().name),
			dialogHolder.TalkDialog ("要拿下來嗎？"),
			dialogHolder.AskDialog ("是", "否", new List<Dialog> { dialogHolder.TalkDialog ("放在這是對的嗎？") }),
			dialogHolder.TalkDialog ("拿下了 " + currentMask.GetComponent<ItemData> ().name)
		};
	}

	void WearMask(GameObject whatMaskToWear){
		currentMask = Instantiate (whatMaskToWear);
		currentMask.name = whatMaskToWear.name;
		currentMask.transform.SetParent (this.transform);
		currentMask.transform.localScale = new Vector3 (3.2f, 3.2f, 1);
		currentMask.transform.localPosition = new Vector3 (0, 2.5f, 0);
	}

	void OnDialogOver(object sender, EventArgs e)
	{	
		if (currentMask == null) {
			if (dialogHolder.AskDialogAnswerList [0] == 1) {
				if (player.GetComponent<PlayerInventory> ().IsSomethingInInventory ("HappyMask")) {
					player.GetComponent<PlayerInventory> ().DropItem ("HappyMask");
					WearMask (happyMask);
				}
			} else if (dialogHolder.AskDialogAnswerList [1] == 1) {
				if (player.GetComponent<PlayerInventory> ().IsSomethingInInventory ("AngryMask")) {
					player.GetComponent<PlayerInventory> ().DropItem ("AngryMask");
					WearMask (angryMask);
				}
			} else if (dialogHolder.AskDialogAnswerList [2] == 1) {
				if (player.GetComponent<PlayerInventory> ().IsSomethingInInventory ("SadMask")) {
					player.GetComponent<PlayerInventory> ().DropItem ("SadMask");
					WearMask (sadMask);
				}
			} else if (dialogHolder.AskDialogAnswerList [3] == 1) {
				if (player.GetComponent<PlayerInventory> ().IsSomethingInInventory ("BoringMask")) {
					player.GetComponent<PlayerInventory> ().DropItem ("BoringMask");
					WearMask (boringMask);
				}
			}
		} else if (dialogHolder.AskDialogAnswerList [0] == 1) {
			if (this.transform.childCount > 1) {
				player.GetComponent<PlayerInventory> ().PickUpItem (this.transform.GetChild (1).gameObject);
				GameObject.Destroy (this.transform.GetChild (1));	
			}
		}
	}

}
