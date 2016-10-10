using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class LivingRoom_TVAI : MonoBehaviour {

	public GameObject parentsDoorKey;

	private GameObject player;
	private DialogHolder dialogHolder;
	private GameObject light1;
	private GameObject light2;
	private GameObject light3;
	private GameObject doge;

	private static bool hasDogPopedUp;
	private static bool isDogFed;

	// Use this for initialization
	void Start()
	{
		player = FindObjectOfType<PlayerController> ().gameObject;
		dialogHolder = this.GetComponent<DialogHolder> ();
		light1 = this.transform.FindChild ("ScreenLight1").gameObject;
		light2 = this.transform.FindChild ("ScreenLight2").gameObject;
		light3 = this.transform.FindChild ("ScreenLight3").gameObject;
		doge = this.transform.FindChild ("doge").gameObject;

		this.GetComponent<DialogHolder> ().DialogOverEvent += OnDialogOver;

		doge.SetActive (false);
	}

	// Update is called once per frame
	void Update()
	{
		if (!hasDogPopedUp)
			dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("電視的螢幕上面閃爍著紅色的畫面"),
				dialogHolder.TalkDialog ("按電源鍵也沒有任何反應...")
			};
		else {
			if (!isDogFed) {
				if (player.GetComponent<PlayerInventory> ().IsSomethingInInventory ("Bones"))
					dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("電視的螢幕上面出現了一個奇怪的黑影"),
						dialogHolder.TalkDialog ("感覺在盯著這邊的樣子..."),
						dialogHolder.AskDialog ("將骨頭給他", "將手伸上前", new List<Dialog> {
							dialogHolder.TalkDialog ("嘶嘶嘶嘶－－－－"),
							dialogHolder.TalkDialog ("黑影突然發出的巨大聲響 使你收回了手")
						}),
						dialogHolder.TalkDialog ("咖滋－ 咖滋－"),
						dialogHolder.TalkDialog ("黑影相當開心地嚼著骨頭"),
						dialogHolder.TalkDialog ("一個發亮的東西從電視螢幕裡掉了出來"),
						dialogHolder.PickUpItemDialog ("獲得了 小鑰匙", parentsDoorKey)
					};
				else
					dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("電視的螢幕上面出現了一個奇怪的黑影"),
						dialogHolder.TalkDialog ("感覺在盯著這邊的樣子..."),
						dialogHolder.AskDialog ("將手伸上前", "離開", new List<Dialog> {
							dialogHolder.TalkDialog ("銳利的視線 讓人十分不自在")
						}),
						dialogHolder.TalkDialog ("嘶嘶嘶嘶－－－－"),
						dialogHolder.TalkDialog ("黑影突然發出的巨大聲響 使你收回了手")
					};
			} else
				dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("電視螢幕上面的黑影消失了"),
					dialogHolder.TalkDialog ("只剩下詭異的紅光不斷閃爍著...")
				};
		}
	}
		
	void OnDialogOver(object sender, EventArgs e)
	{
		if (!hasDogPopedUp) {
			Invoke ("TurnOffTheTVAndDog", 0.5f);
			Invoke ("TurnOnTheTVAndDog", 0.55f);
			hasDogPopedUp = true;
		} else if (!isDogFed) {
			if (player.GetComponent<PlayerInventory> ().IsSomethingInInventory ("Bones") && 
				dialogHolder.AskDialogAnswerList.Count > 0 && dialogHolder.AskDialogAnswerList [0] == 1) {
				isDogFed = true;
				player.GetComponent<PlayerInventory> ().DropItem ("Bones");
				Invoke ("TurnOffTheTVAndDog", 0.5f);
				Invoke ("TurnOnTheTV", 0.55f);
			}
		}
	}

	public bool IsTVTurnedOn {
		get {
			if (light1.activeSelf && light2.activeSelf && light3.activeSelf)
				return true;
			else
				return false;
		}
		set { 
			light1.SetActive (value);
			light2.SetActive (value);
			light3.SetActive (value);
		}
	}

	void TurnOnTheTV() {
		IsTVTurnedOn = true;
	}

	void TurnOnTheTVAndDog() {
		IsTVTurnedOn = true;
		doge.SetActive (true);
	}

	void TurnOffTheTVAndDog() {
		IsTVTurnedOn = false;
		doge.SetActive (false);
	}
}
