using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
	public GameObject dBox;
	public Text dText;
	public Image itemImage;
	public Dialog[] dialogs;
	public GameObject nextButton;
	public GameObject yesButton;
	public GameObject noButton;

	private GameObject player;
	private PlayerController playerController;
	private bool dialogActive;
	private int currentDialog;
	private GameObject currentItem;

	private bool askDialogAnswer;

	void Start ()
	{	
		player = FindObjectOfType<PlayerController> ().gameObject;
		playerController = player.GetComponent<PlayerController> ();
		dialogActive = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		dBox.SetActive (dialogActive);
	}

	public void ShowBox (GameObject item)
	{
		currentItem = item;
		dialogs = currentItem.GetComponent<DialogHolder> ().Dialogs;
		playerController.StartTalk ();
		dialogActive = true;

		if(dialogs[currentDialog].Mode == "Talk"){
			dText.text = dialogs [currentDialog].Content;
			nextButton.SetActive (true);
			yesButton.SetActive (false);
			noButton.SetActive (false);
		}			
		else if (dialogs[currentDialog].Mode == "Ask"){
			dText.text = dialogs [currentDialog].Content;
			nextButton.SetActive (false);
			yesButton.SetActive (true);
			noButton.SetActive (true);
		}
		else if (dialogs[currentDialog].Mode == "Pick"){
			dText.text = dialogs [currentDialog].Content;
			nextButton.SetActive (true);
			yesButton.SetActive (false);
			noButton.SetActive (false);

			GameObject k = Instantiate (dialogs[currentDialog].Item);
			k.name = dialogs[currentDialog].Item.name;
			player.GetComponent<PlayerInventory> ().PickUpItem (k);
		}

		if (currentItem.GetComponent<SpriteRenderer> ()) {
			itemImage.color = new Color(255, 255, 255, 1);
			itemImage.sprite = currentItem.GetComponent<SpriteRenderer> ().sprite;
		}
		else 
			itemImage.color = new Color(255, 255, 255, 0);		
	}

	public void ContinueDialog ()	
	{
		if (dialogActive && (currentDialog <= dialogs.Length - 1)) 
		{
			currentDialog++;

			//如果currentLine超過dialogLines.Length則不更新dText.text

			if (currentDialog >= dialogs.Length) 
			{
				dialogActive = false;
				currentDialog = 0;
				currentItem.GetComponent<DialogHolder> ().EndTalk ();
				playerController.EndTalk ();
				if (currentItem.CompareTag ("Item"))
					player.GetComponent<PlayerInventory> ().PickUpItem (currentItem);
			} 
			else 
			{
				if(dialogs[currentDialog].Mode == "Talk"){
					dText.text = dialogs [currentDialog].Content;
					nextButton.SetActive (true);
					yesButton.SetActive (false);
					noButton.SetActive (false);
				}			
				else if (dialogs[currentDialog].Mode == "Ask"){
					if (askDialogAnswer)
						dText.text = dialogs [currentDialog].Content;
					else {
						dText.text = dialogs [currentDialog].DenyContent;
						currentDialog = dialogs.Length - 1;
					}
					nextButton.SetActive (false);
					yesButton.SetActive (true);
					noButton.SetActive (true);
				}
				else if (dialogs[currentDialog].Mode == "Pick"){
					dText.text = dialogs [currentDialog].Content;
					GameObject g = Instantiate (dialogs[currentDialog].Item);
					g.name = dialogs[currentDialog].Item.name;
					player.GetComponent<PlayerInventory> ().PickUpItem (g);
					nextButton.SetActive (true);
					yesButton.SetActive (false);
					noButton.SetActive (false);
				}
					
			}
		}
	}

	public bool IsDialogActive {
		get{ return dialogActive; }
	}

	public void ClickYesButton(){
		askDialogAnswer = true;
		ContinueDialog ();
	}

	public void ClickNoButton(){
		askDialogAnswer = false;
		dText.text = dialogs [currentDialog].DenyContent;
		nextButton.SetActive (true);
		yesButton.SetActive (false);
		noButton.SetActive (false);
		currentDialog = dialogs.Length - 1;
	}

	public bool AskDialogAnswer {
		get{ return askDialogAnswer; }
	}

}