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
	private int currentDialogIndex;
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

	public void ShowBox (GameObject gameobject)
	{
		currentItem = gameobject;
		dialogs = currentItem.GetComponent<DialogHolder> ().Dialogs;
		playerController.StartTalk ();
		dialogActive = true;

		if(dialogs[currentDialogIndex].Mode == "Talk"){
			dText.text = dialogs [currentDialogIndex].Content;
			nextButton.SetActive (true);
			yesButton.SetActive (false);
			noButton.SetActive (false);
		}			
		else if (dialogs[currentDialogIndex].Mode == "Ask"){
			dText.text = dialogs [currentDialogIndex].Content;
			nextButton.SetActive (false);
			yesButton.SetActive (true);
			noButton.SetActive (true);
		}
		else if (dialogs[currentDialogIndex].Mode == "Pick"){
			dText.text = dialogs [currentDialogIndex].Content;
			nextButton.SetActive (true);
			yesButton.SetActive (false);
			noButton.SetActive (false);

			GameObject item = Instantiate (dialogs[currentDialogIndex].Item);
			item.name = dialogs[currentDialogIndex].Item.name;
			player.GetComponent<PlayerInventory> ().PickUpItem (item);
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
		if (dialogActive && (currentDialogIndex <= dialogs.Length - 1)) 
		{
			currentDialogIndex++;

			//如果currentLine超過dialogLines.Length則不更新dText.text

			if (currentDialogIndex >= dialogs.Length) 
			{
				dialogActive = false;
				currentDialogIndex = 0;
				currentItem.GetComponent<DialogHolder> ().IsDialogOver = true;
				playerController.EndTalk ();
				if (currentItem.CompareTag ("Item"))
					player.GetComponent<PlayerInventory> ().PickUpItem (currentItem);
			} 
			else 
			{
				if(dialogs[currentDialogIndex].Mode == "Talk"){
					dText.text = dialogs [currentDialogIndex].Content;
					nextButton.SetActive (true);
					yesButton.SetActive (false);
					noButton.SetActive (false);
				}			
				else if (dialogs[currentDialogIndex].Mode == "Ask"){
					if (askDialogAnswer)
						dText.text = dialogs [currentDialogIndex].Content;
					else {
						dText.text = dialogs [currentDialogIndex].DenyContent;
						currentDialogIndex = dialogs.Length - 1;
					}
					nextButton.SetActive (false);
					yesButton.SetActive (true);
					noButton.SetActive (true);
				}
				else if (dialogs[currentDialogIndex].Mode == "Pick"){
					dText.text = dialogs [currentDialogIndex].Content;
					GameObject g = Instantiate (dialogs[currentDialogIndex].Item);
					g.name = dialogs[currentDialogIndex].Item.name;
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
		dText.text = dialogs [currentDialogIndex].DenyContent;
		nextButton.SetActive (true);
		yesButton.SetActive (false);
		noButton.SetActive (false);
		currentDialogIndex = dialogs.Length - 1;
	}

	public bool AskDialogAnswer {
		get{ return askDialogAnswer; }
	}

}