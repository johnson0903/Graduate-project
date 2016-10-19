using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

public class OverSceneManager : MonoBehaviour {

	public GameObject blackShow;
	public GameObject slideShow1;
	public GameObject slideShow2;
	public GameObject slideShow3;
	public GameObject slideShow4;
	public GameObject slideShow5;
	public GameObject slideShow6;
	public GameObject slideShow7;
	public GameObject slideShow8;
	public GameObject slideShow9;
	public Image dark;

	private DialogManager dialogManager;
	private DialogHolder dialogHolder;
	private int currentSceneCount;

	private bool isFadingIn;
	private bool isFadingOut;
	private bool isDialogAutoPopup;

	// Use this for initialization
	void Start () {
		dialogHolder = this.GetComponent<DialogHolder> ();
		this.GetComponent<DialogHolder>().DialogOverEvent += OnDialogOver;
	
		currentSceneCount = 0;

		blackShow.SetActive (false);
		slideShow1.SetActive (false);
		slideShow2.SetActive (false);
		slideShow3.SetActive (false);
		slideShow4.SetActive (false);
		slideShow5.SetActive (false);
		slideShow6.SetActive (false);
		slideShow7.SetActive (false);
		slideShow8.SetActive (false);
		slideShow9.SetActive (false);
		isFadingIn = false;
		isFadingOut = true;
	}

	// Update is called once per frame
	void Update () {
		if (currentSceneCount == 0) {
			ChangeImageByFade (blackShow, slideShow1);
			dialogHolder.Dialogs = new List<Dialog> {
				dialogHolder.TalkDialog ("頭好痛..."),
				dialogHolder.TalkDialog ("腦袋像是被清空的 想不起來剛剛發生了什麼事")
			};
		} else if (currentSceneCount == 1) {
			ChangeImageByFade (slideShow1, slideShow2);
			dialogHolder.Dialogs = new List<Dialog> {
				dialogHolder.TalkDialog ("頭好痛..."),
				dialogHolder.TalkDialog ("腦袋像是被清空的 想不起來剛剛發生了什麼事")
			};
		} else if (currentSceneCount == 2) {
			ChangeImageByFade (slideShow2, slideShow3);
			dialogHolder.Dialogs = new List<Dialog> {
				dialogHolder.TalkDialog ("這裡是哪？"),
				dialogHolder.TalkDialog ("我倒在這裡...已經有多久了？"),
				dialogHolder.TalkDialog ("揉著惺忪的雙眼 你緩緩地從床上起身")
			};
		} else if (currentSceneCount == 3) {
			ChangeImageByFade (slideShow3, slideShow4);
			dialogHolder.Dialogs = new List<Dialog> {
				dialogHolder.TalkDialog ("你坐在床邊 甚至連自己的名字都想不太起來"),
				dialogHolder.TalkDialog ("我為什麼... 會在這裡呢...？"),
				dialogHolder.TalkDialog ("環顧身旁 也沒有一個能夠詢問的對象"),
				dialogHolder.TalkDialog ("你抱著滿腹的疑問 從床上站了起來"),
				dialogHolder.TalkDialog ("先掌握一下情況吧")
			};
		} else if (currentSceneCount == 4) {
			ChangeImageByFade (slideShow4, slideShow5);
			dialogHolder.Dialogs = new List<Dialog> {
				dialogHolder.TalkDialog ("你坐在床邊 甚至連自己的名字都想不太起來"),
				dialogHolder.TalkDialog ("我為什麼... 會在這裡呢...？"),
				dialogHolder.TalkDialog ("環顧身旁 也沒有一個能夠詢問的對象"),
				dialogHolder.TalkDialog ("你抱著滿腹的疑問 從床上站了起來"),
				dialogHolder.TalkDialog ("先掌握一下情況吧")
			};
		} else if (currentSceneCount == 5) {
			ChangeImageByFade (slideShow5, slideShow6);
			dialogHolder.Dialogs = new List<Dialog> {
				dialogHolder.TalkDialog ("你坐在床邊 甚至連自己的名字都想不太起來"),
				dialogHolder.TalkDialog ("我為什麼... 會在這裡呢...？"),
				dialogHolder.TalkDialog ("環顧身旁 也沒有一個能夠詢問的對象"),
				dialogHolder.TalkDialog ("你抱著滿腹的疑問 從床上站了起來"),
				dialogHolder.TalkDialog ("先掌握一下情況吧")
			};
		} else if (currentSceneCount == 6) {
			ChangeImageByFade (slideShow6, slideShow7);
			dialogHolder.Dialogs = new List<Dialog> {
				dialogHolder.TalkDialog ("你坐在床邊 甚至連自己的名字都想不太起來"),
				dialogHolder.TalkDialog ("我為什麼... 會在這裡呢...？"),
				dialogHolder.TalkDialog ("環顧身旁 也沒有一個能夠詢問的對象"),
				dialogHolder.TalkDialog ("你抱著滿腹的疑問 從床上站了起來"),
				dialogHolder.TalkDialog ("先掌握一下情況吧")
			};
		} else if (currentSceneCount == 7) {
			ChangeImageByFade (slideShow7, slideShow8);
			dialogHolder.Dialogs = new List<Dialog> {
				dialogHolder.TalkDialog ("你坐在床邊 甚至連自己的名字都想不太起來"),
				dialogHolder.TalkDialog ("我為什麼... 會在這裡呢...？"),
				dialogHolder.TalkDialog ("環顧身旁 也沒有一個能夠詢問的對象"),
				dialogHolder.TalkDialog ("你抱著滿腹的疑問 從床上站了起來"),
				dialogHolder.TalkDialog ("先掌握一下情況吧")
			};
		} else if (currentSceneCount == 8) {
			ChangeImageByFade (slideShow8, slideShow9);
			dialogHolder.Dialogs = new List<Dialog> {
				dialogHolder.TalkDialog ("你坐在床邊 甚至連自己的名字都想不太起來"),
				dialogHolder.TalkDialog ("我為什麼... 會在這裡呢...？"),
				dialogHolder.TalkDialog ("環顧身旁 也沒有一個能夠詢問的對象"),
				dialogHolder.TalkDialog ("你抱著滿腹的疑問 從床上站了起來"),
				dialogHolder.TalkDialog ("先掌握一下情況吧")
			};
		}

		if (isFadingIn)
			dark.color = new Color (1, 1, 1, Mathf.Lerp (dark.color.a, 1, 0.05f));
		else if (isFadingOut) {
			dark.color = new Color (1, 1, 1, Mathf.Lerp (dark.color.a, 0, 0.05f));
			if (dark.color.a <= 0.05)
				isFadingOut = false;
		}
	}
		
	void ChangeImageByFade(GameObject currentImage, GameObject nextImage){
		if (dark.color.a >= 0.99) {
			isFadingIn = false;
			isFadingOut = true;
			currentImage.SetActive (false);
			nextImage.SetActive (true);
		} else if (dark.color.a <= 0.05) {
			if (isDialogAutoPopup) {
				dialogHolder.ShowDialogInMainScene ();
				isDialogAutoPopup = false;
			} else if (Input.GetKeyDown (KeyCode.Space))
				dialogHolder.ShowDialogInMainScene ();
		}
	}

	void OnDialogOver(object sender, EventArgs e)
	{	
		isFadingIn = true;
		currentSceneCount++;
		isDialogAutoPopup = true;
	}
}
