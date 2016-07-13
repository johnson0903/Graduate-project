using UnityEngine;
using System.Collections;

public class PillowAI : MonoBehaviour {

	public GameObject key;

	private GameObject player;
	private DialogHolder dialogHolder;
	private static bool isPillowKeyTaken;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ().gameObject;
		dialogHolder = this.GetComponent<DialogHolder> ();
	}

	// Update is called once per frame
	void Update () {

		if (!isPillowKeyTaken) {
			if (player.GetComponent<PlayerInventory> ().isSomethingInInventory ("BoxCutter")) {
				dialogHolder.Dialogs = new Dialog[] { dialogHolder.TalkDialog ("用刀子劃開了枕頭"), dialogHolder.TalkDialog ("獲得了 大門的鑰匙") };
				if (dialogHolder.IsDialogOver) {
					GameObject k = Instantiate (key);
					k.name = key.name;
					isPillowKeyTaken = true;
					player.GetComponent<PlayerInventory> ().PickUpItem (k);
				}
			} else {
				dialogHolder.Dialogs = new Dialog[] { dialogHolder.TalkDialog ("軟綿綿的枕頭"), dialogHolder.TalkDialog ("但裡面好像有一個硬硬的東西") };
			}
		}

		else if (isPillowKeyTaken) {
			dialogHolder.Dialogs = new Dialog[] { dialogHolder.TalkDialog ("撕碎的枕頭散落在床上"), dialogHolder.TalkDialog ("瞧你都幹了什麼") };
		}
	}

}
