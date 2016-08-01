using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class Bedroom_PencilTombPaintAI : MonoBehaviour {

	private GameObject player;
	private DialogHolder dialogHolder;
	private static bool changeSceneByPencilTombPaint;
	private static bool isDialogPopUpInPencilTombPaint;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ().gameObject;
		dialogHolder = this.GetComponent<DialogHolder> ();
		this.GetComponent<DialogHolder> ().DialogOverEvent += OnDialogOver;

		if (changeSceneByPencilTombPaint) {	
			player.transform.position = new Vector3 (this.transform.position.x, player.transform.position.y, player.transform.position.z);
			changeSceneByPencilTombPaint = false;
		}

		if(SceneManager.GetActiveScene ().buildIndex == 2 && !isDialogPopUpInPencilTombPaint)
			dialogHolder.IsAutoPopUp = true;

	}

	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene ().buildIndex == 0)
			dialogHolder.Dialogs = new Dialog[] {
			dialogHolder.TalkDialog ("一幅奇怪的畫"),
			dialogHolder.AskDialog ("繼續看", "移開視線", new Dialog[]{ dialogHolder.TalkDialog ("找找其他地方吧") }),
			dialogHolder.TalkDialog ("感覺意識要被吸進去了"),
			dialogHolder.TalkDialog (".....!?")
		};
		else {
			if (!isDialogPopUpInPencilTombPaint)
				dialogHolder.Dialogs = new Dialog[] {
				dialogHolder.TalkDialog (".......?"),
				dialogHolder.TalkDialog ("這裡是哪裡"),
			};
			else
				dialogHolder.Dialogs = new Dialog[] {
				dialogHolder.TalkDialog (".........."),
				dialogHolder.AskDialog ("回去", "待著", new Dialog[] {
					dialogHolder.TalkDialog ("再調查一下好了")
				}), dialogHolder.TalkDialog ("..................")
			};
		}
	}


	void OnDialogOver (object sender, EventArgs e)
	{
		if(SceneManager.GetActiveScene ().buildIndex == 2)
			isDialogPopUpInPencilTombPaint = true;

		changeSceneByPencilTombPaint = true;
		if (dialogHolder.AskDialogAnswer == 1) {
			if (SceneManager.GetActiveScene ().buildIndex == 0)
				SceneManager.LoadScene (2);
			else
				SceneManager.LoadScene (0);
		}
	}
}
