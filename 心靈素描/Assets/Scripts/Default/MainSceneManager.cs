using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

public class MainSceneManager : MonoBehaviour {

	public GameObject mainScene;
	public GameObject slideShow1;
	public GameObject slideShow2;
	public GameObject slideShow3;
	public Image dark;

	private DialogManager dialogManager;
	private DialogHolder dialogHolder;
	private GameObject startGameButton;
	private GameObject settingGameButton;
	private GameObject selectedButtonImage;
	private GameObject gameSettingImage;
	private int selectedButtonCount;
	private int currentSceneCount;

	private bool isFadingIn;
	private bool isFadingOut;
	private bool isDialogAutoPopup;

	// Use this for initialization
	void Start () {
		dialogHolder = this.GetComponent<DialogHolder> ();
		this.GetComponent<DialogHolder>().DialogOverEvent += OnDialogOver;

		startGameButton = mainScene.transform.FindChild ("StartGameButton").gameObject;
		settingGameButton = mainScene.transform.FindChild ("SettingGameButton").gameObject;
		selectedButtonImage = mainScene.transform.FindChild ("SelectedButtonImage").gameObject;
		gameSettingImage = mainScene.transform.FindChild ("GameSettingImage").gameObject;
		selectedButtonCount = 0;
		currentSceneCount = 0;

		gameSettingImage.SetActive (false);
		slideShow1.SetActive (false);
		slideShow2.SetActive (false);
		slideShow3.SetActive (false);
		isFadingIn = false;
		isFadingOut = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentSceneCount == 0)
			SelectButton ();
		else if (currentSceneCount == 1) {
			ChangeImageByFade (mainScene, slideShow1);
			dialogHolder.Dialogs = new List<Dialog> {
				dialogHolder.TalkDialog ("頭好痛..."),
				dialogHolder.TalkDialog ("腦袋像是被清空的 想不起來剛剛發生了什麼事")
			};
		} else if (currentSceneCount == 2) {
			ChangeImageByFade (slideShow1, slideShow2);
			dialogHolder.Dialogs = new List<Dialog> {
				dialogHolder.TalkDialog ("這裡是哪？"),
				dialogHolder.TalkDialog ("我倒在這裡...已經有多久了？"),
				dialogHolder.TalkDialog ("揉著惺忪的雙眼 你緩緩地從床上起身")
			};
		} else if (currentSceneCount == 3) {
			ChangeImageByFade (slideShow2, slideShow3);
			dialogHolder.Dialogs = new List<Dialog> {
				dialogHolder.TalkDialog ("你坐在床邊 甚至連自己的名字都想不太起來"),
				dialogHolder.TalkDialog ("我為什麼... 會在這裡呢...？"),
				dialogHolder.TalkDialog ("環顧身旁 也沒有一個能夠詢問的對象"),
				dialogHolder.TalkDialog ("你抱著滿腹的疑問 從床上站了起來"),
				dialogHolder.TalkDialog ("先掌握一下情況吧")
			};
		} else if (currentSceneCount == 4)
			ChangeSceneByFade (1);	

		if (isFadingIn)
			dark.color = new Color (1, 1, 1, Mathf.Lerp (dark.color.a, 1, 0.05f));
		else if (isFadingOut) {
			dark.color = new Color (1, 1, 1, Mathf.Lerp (dark.color.a, 0, 0.05f));
			if (dark.color.a <= 0.05)
				isFadingOut = false;
		}
	}

	void SelectButton() {
		if (selectedButtonCount == 0)
			selectedButtonImage.GetComponent<Image>().rectTransform.anchoredPosition = Vector2.Lerp (selectedButtonImage.GetComponent<Image>().rectTransform.anchoredPosition, new Vector2 (0, startGameButton.GetComponent<Text>().rectTransform.anchoredPosition.y), 0.2f);
		else
			selectedButtonImage.GetComponent<Image>().rectTransform.anchoredPosition = Vector2.Lerp (selectedButtonImage.GetComponent<Image>().rectTransform.anchoredPosition, new Vector2 (0, settingGameButton.GetComponent<Text>().rectTransform.anchoredPosition.y), 0.2f);
		
		if (!gameSettingImage.activeSelf) {
			if ((Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W)) && selectedButtonCount == 1)
				selectedButtonCount -= 1;
			else if ((Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.S)) && selectedButtonCount == 0)
				selectedButtonCount += 1;
			if (Input.GetKeyDown (KeyCode.Space)) {
				if (selectedButtonCount == 0) {
					isFadingIn = true;
					currentSceneCount++;
					isDialogAutoPopup = true;
				} else
					gameSettingImage.SetActive (true);
			}
		} else if (Input.GetKeyDown (KeyCode.Space))
			gameSettingImage.SetActive (false);

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
		
	void ChangeSceneByFade(int whereToGo){
		if (dark.color.a >= 0.99) 
			SceneManager.LoadScene (whereToGo);
	}

	void OnDialogOver(object sender, EventArgs e)
	{	
		isFadingIn = true;
		currentSceneCount++;
		isDialogAutoPopup = true;
	}

}
