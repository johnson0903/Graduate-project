using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;

public class PencilTombPaint_DoorAI : MonoBehaviour {

	private GameObject player;
	private DialogHolder dialogHolder;
	private SceneLoader sceneLoader;

	private static bool hasDialogPopUpInPencilTombPaint;
	private static bool ChangeSceneByPencilTombDoor;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ().gameObject;
		dialogHolder = this.GetComponent<DialogHolder> ();
		sceneLoader = FindObjectOfType<SceneLoader> ();
		this.GetComponent<DialogHolder> ().DialogOverEvent += OnDialogOver;

		if (ChangeSceneByPencilTombDoor) {	
			player.transform.position = new Vector3 (this.transform.position.x, player.transform.position.y, player.transform.position.z);
			ChangeSceneByPencilTombDoor = false;
		}
			
		if(SceneManager.GetActiveScene ().buildIndex == 2 && !hasDialogPopUpInPencilTombPaint)
			dialogHolder.IsAutoPopUp = true;
	}

	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene ().buildIndex == 0) {
			dialogHolder.Dialogs = new List<Dialog> {
				dialogHolder.TalkDialog ("牆上掛著一幅奇怪的畫"),
				dialogHolder.AskDialog ("繼續盯著看", "離開", new List<Dialog> {
					dialogHolder.TalkDialog ("有種奇怪的感覺...")
				}), dialogHolder.TalkDialog ("感覺...意志要被吸進去了")
			};
		} else {
			if (!hasDialogPopUpInPencilTombPaint)
				dialogHolder.Dialogs = new List<Dialog> {
					dialogHolder.TalkDialog (".......?"),
					dialogHolder.TalkDialog ("這裡是哪裡"),
				};
			else
				dialogHolder.Dialogs = new List<Dialog> {
					dialogHolder.TalkDialog (".........."),
					dialogHolder.AskDialog ("回去", "待著", new List<Dialog> {
						dialogHolder.TalkDialog ("再調查一下好了")
					}), dialogHolder.TalkDialog ("..................")
				};
		}
	}
		
	void OnDialogOver (object sender, EventArgs e)
	{
		if (SceneManager.GetActiveScene ().buildIndex == 0) {
			if (dialogHolder.AskDialogAnswerList [0] == 1) {
				ChangeSceneByPencilTombDoor = true;
				sceneLoader.LoadScene (2);		
			}
		} else {
			if (!hasDialogPopUpInPencilTombPaint)
				hasDialogPopUpInPencilTombPaint = true;
			else if (dialogHolder.AskDialogAnswerList [0] == 1) {
				ChangeSceneByPencilTombDoor = true;
				sceneLoader.LoadScene (0);
			}
		}
	}

}

