using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class UmbrellaGirlTriggerAI : MonoBehaviour {

	public GameObject umbrellaGirl;
	public GameObject umBrellaGirlPaint_Left;
	public GameObject umBrellaGirlPaint_Right;
	public Sprite umbrellaGirlWithBlood_Left;
	public Sprite umbrellaGirlWithBlood_Right;
	public Sprite black;

	private DialogHolder dialogHolder;

	private static bool isShockedInCorridor;

	// Use this for initialization
	void Start () {
		dialogHolder = this.GetComponent<DialogHolder> ();
		this.GetComponent<DialogHolder> ().DialogOverEvent += OnDialogOver;
	}

	// Update is called once per frame
	void Update () {
		if (!isShockedInCorridor) {
			if (umBrellaGirlPaint_Left.transform.FindChild ("GirlWithUmbrella").GetComponent<SpriteRenderer> ().sprite == umbrellaGirlWithBlood_Left &&
			    umBrellaGirlPaint_Right.transform.FindChild ("GirlWithNoUmbrella").GetComponent<SpriteRenderer> ().sprite == umbrellaGirlWithBlood_Right) {
				dialogHolder.IsAutoPopUp = true;
				umbrellaGirl.SetActive (true);
				umBrellaGirlPaint_Left.transform.FindChild ("GirlWithUmbrella").GetComponent<SpriteRenderer> ().sprite = black;
			}
			dialogHolder.Dialogs = new List<Dialog> {
				dialogHolder.TalkDialog ("........."),
				dialogHolder.TalkDialog ("......!!!"),
			};
		} else
			dialogHolder.Dialogs = null;

		if (umbrellaGirl.GetComponent<UmbrellaGirlAI> ().IsOver) {
			umBrellaGirlPaint_Left.transform.FindChild ("GirlWithUmbrella").GetComponent<SpriteRenderer> ().sprite = umbrellaGirlWithBlood_Left;
			umbrellaGirl.SetActive (false);
		}
		
	}

	void OnDialogOver (object sender, EventArgs e)
	{
		umbrellaGirl.GetComponent<UmbrellaGirlAI> ().Move ();
		isShockedInCorridor = true;
	}

}
