using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Bathroom_ToiletAI : MonoBehaviour {

	public Sprite closedToilet;
	public Sprite openedToilet;

	private GameObject player;
	private DialogHolder dialogHolder;
	public GameObject toilet;
	public Sprite openToilet;
	public Sprite closeToilet;
	private bool isToiletOpen;

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
		dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("用陶瓷做的 純白色的馬桶"),
			dialogHolder.TalkDialog ("馬桶蓋子是蓋上的"),
			dialogHolder.AskDialog ("將蓋子打開", "不理他", new List<Dialog> {
				dialogHolder.TalkDialog ("調查其他地方吧")
			}),
			dialogHolder.EventDialog("嘎拉－", true, 0, .2f)
		};
	}

	void OnDialogOver(object sender, EventArgs e)
	{
		isToiletOpen = !isToiletOpen;
		if (!isToiletOpen)
			toilet.GetComponent<SpriteRenderer>().sprite = openToilet;
		else
			toilet.GetComponent<SpriteRenderer>().sprite = openToilet;
			
=======
		if (this.GetComponent<SpriteRenderer> ().sprite == closedToilet) {
			dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("用陶瓷做的 純白色的馬桶"),
				dialogHolder.TalkDialog ("馬桶蓋子是蓋上的"),
				dialogHolder.AskDialog ("將蓋子打開", "不理他", new List<Dialog> {
					dialogHolder.TalkDialog ("調查其他地方吧")
				}),
				dialogHolder.EventDialog ("嘎拉－", true, 0, .5f),
				dialogHolder.TalkDialog ("沒發現什麼特別的東西...")
			};
		} else
			dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("用陶瓷做的 純白色的馬桶"),
				dialogHolder.TalkDialog ("馬桶蓋子是打開的"),
				dialogHolder.AskDialog ("將蓋子蓋上", "不理他", new List<Dialog> {
					dialogHolder.TalkDialog ("調查其他地方吧")
				}),
				dialogHolder.EventDialog ("嘎拉－", true, 0, .5f),
				dialogHolder.TalkDialog ("你將打開的馬桶蓋蓋上了")
			};
	}

	void OnDialogOver(object sender, EventArgs e)
	{	
>>>>>>> 5958b7edb1a823e5d68c073da0572aecee400eb1
	}

	void OnEventDialogOccur(object sender, EventArgs e)
	{	
		if (this.GetComponent<SpriteRenderer> ().sprite == closedToilet)
			this.GetComponent<SpriteRenderer> ().sprite = openedToilet;
		else
			this.GetComponent<SpriteRenderer> ().sprite = closedToilet;
	}

}
