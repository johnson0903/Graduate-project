using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogManager : MonoBehaviour
{
	public GameObject dBox;
	public Text dText;
	public GameObject answer1;
	public GameObject answer2;	
	public GameObject escape;
	public GameObject pickUpItemImage;
	public AudioClip mouseEffectClip;
	public AudioClip dialogOpenClip;

    private AudioSource audioSource;
	private List<Dialog> dialogs;
	private GameObject player;

	private PlayerController playerController;

	private GameObject talkingObeject;
	private bool isDialogActive;
	private int askDialogAnswer;
	private int currentDialogIndex;
	private bool isDialogDelay;

	private List<int> askDialogAnswerList = new List<int> ();

	void Start()
	{
		player = FindObjectOfType<PlayerController> ().gameObject;
		playerController = player.GetComponent<PlayerController> ();
        audioSource = GetComponent<AudioSource>();
		answer1.SetActive (false);
		answer2.SetActive (false);
		pickUpItemImage.SetActive (false);
		isDialogActive = false;
	}

	void Update()
	{
		dBox.SetActive (isDialogActive);

		if (answer1.activeSelf && answer2.gameObject.activeSelf) {
			ShowAnswerMenu ();
			if (Input.GetKeyDown (KeyCode.Escape)) {
				audioSource.PlayOneShot (dialogOpenClip, .3f);
				isDialogActive = false;
				playerController.YouCanMove ();
			}
		}
	}

	void ShowAnswerMenu()
	{
		Color chosenColor = new Color (1, 1, 1, 0.5f);
		Color notChosenColor = new Color (1, 1, 1, 0);

		if (askDialogAnswer == 1) {
			answer1.GetComponent<Image> ().color = chosenColor;
			answer2.GetComponent<Image> ().color = notChosenColor;
			answer1.transform.FindChild ("Pointer").gameObject.SetActive (true);
			answer2.transform.FindChild ("Pointer").gameObject.SetActive (false);
		} else {
			answer1.GetComponent<Image> ().color = notChosenColor;
			answer2.GetComponent<Image> ().color = chosenColor;
			answer1.transform.FindChild ("Pointer").gameObject.SetActive (false);
			answer2.transform.FindChild ("Pointer").gameObject.SetActive (true);
		}

		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W) ||
		    Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.S)) {
			audioSource.PlayOneShot (mouseEffectClip, .3f);
			if (askDialogAnswer == 1)
				askDialogAnswer = 2;
			else
				askDialogAnswer = 1;
			
		}
	}

	void ShowDialogByMode()
	{
		//根據上一個對話的回答，檢查之後的對話是否要被替換
		if (currentDialogIndex > 0 && dialogs [currentDialogIndex - 1].Mode == "Ask") {
			askDialogAnswerList.Add (askDialogAnswer);
			if (askDialogAnswer == 1) {
			} else if (askDialogAnswer == 2) {
				dialogs.RemoveRange (currentDialogIndex, dialogs.Count - currentDialogIndex);
				dialogs.AddRange (dialogs [currentDialogIndex - 1].Answer2_Dialogs);
			}	
		}

		if (dialogs [currentDialogIndex].Mode == "Talk") {
			dText.text = dialogs [currentDialogIndex].Content;
			answer1.SetActive (false);
			answer2.SetActive (false);
			escape.SetActive (false);
			pickUpItemImage.SetActive (false);
		} else if (dialogs [currentDialogIndex].Mode == "Ask") {
			askDialogAnswer = 1;
			answer1.SetActive (true);
			answer2.SetActive (true);
			escape.SetActive (true);
			pickUpItemImage.SetActive (false);
			answer1.GetComponentInChildren<Text> ().text = dialogs [currentDialogIndex].Answer1;
			answer2.GetComponentInChildren<Text> ().text = dialogs [currentDialogIndex].Answer2;
		} else if (dialogs [currentDialogIndex].Mode == "Pick") {
			dText.text = dialogs [currentDialogIndex].Content;
			GameObject g = Instantiate (dialogs [currentDialogIndex].Item);
			g.name = dialogs [currentDialogIndex].Item.name;
			player.GetComponent<PlayerInventory> ().PickUpItem (g);
			answer1.SetActive (false);
			answer2.SetActive (false);
			escape.SetActive (false);
			pickUpItemImage.SetActive (true);
			pickUpItemImage.transform.FindChild("ItemImage").GetComponent<Image> ().sprite = dialogs [currentDialogIndex].Item.GetComponent<SpriteRenderer> ().sprite;
		} else if (dialogs [currentDialogIndex].Mode == "PlaySound") {
			dText.text = dialogs [currentDialogIndex].Content;
			answer1.SetActive (false);
			answer2.SetActive (false);
			escape.SetActive (false);
			pickUpItemImage.SetActive (false);
			audioSource.clip = dialogs [currentDialogIndex].audioClip;
			audioSource.PlayOneShot (audioSource.clip, dialogs [currentDialogIndex].ClipVolumn);
			if (audioSource.clip.length > 1.6)
				lockDialog ();
		}
        
	}

	public void StartDialog(GameObject gameobject)
	{
		if (!player.GetComponent<PlayerInventory> ().bag.activeSelf) {
			if (!isDialogActive) {
				audioSource.PlayOneShot (dialogOpenClip, .3f);
				talkingObeject = gameobject;
				dialogs = talkingObeject.GetComponent<DialogHolder> ().Dialogs;
				playerController.DontMove ();
				isDialogActive = true;
				currentDialogIndex = 0;
				ShowDialogByMode ();
				askDialogAnswerList.Clear ();
			}
		}
	}

	public void ContinueDialog(GameObject gameobject)
	{
		if (talkingObeject == gameobject && !isDialogDelay) {
			currentDialogIndex++;
			if (currentDialogIndex >= dialogs.Count) {
				isDialogActive = false;
				playerController.YouCanMove ();
				audioSource.PlayOneShot (dialogOpenClip, .3f);
				talkingObeject.GetComponent<DialogHolder> ().TellObjectDialogIsOver ();
			} else { 
				ShowDialogByMode ();
				audioSource.PlayOneShot (mouseEffectClip, .3f);
			}
		}
	}

	public bool IsDialogActive {
		get { return isDialogActive; }
	}

	public List<int> AskDialogAnswerList {
		get { return askDialogAnswerList; }
	}

	void lockDialog() {
		isDialogDelay = true;
		Invoke ("UnlockDialog", 1);
	}

	void UnlockDialog() {
		isDialogDelay = false;
	}
}