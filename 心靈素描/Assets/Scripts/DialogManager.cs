using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
	public GameObject dBox;
	public GameObject nextButton;
	public GameObject yesButton;
	public GameObject noButton;
	public Text dText;
	public Image itemImage;
	public Dialog[] dialogs;

	private GameObject player;
	private GameObject currentItem;
	private PlayerController playerController;
	private bool isdialogActive;
	private int currentDialogIndex;


	private bool askDialogAnswer;

	void Start()
	{
		player = FindObjectOfType<PlayerController>().gameObject;
		playerController = player.GetComponent<PlayerController>();
		isdialogActive = false;
	}

	// Update is called once per frame
	void Update()
	{
		dBox.SetActive(isdialogActive);
	}

	public void ShowBox(GameObject gameobject)
	{
		currentItem = gameobject;
		dialogs = currentItem.GetComponent<DialogHolder>().Dialogs;

		//這行不知道有沒有要刪掉?
		playerController.StartTalk();

		isdialogActive = true;

		if (dialogs[currentDialogIndex].Mode == "Talk")
		{
			dText.text = dialogs[currentDialogIndex].Content;
			nextButton.SetActive(true);
			yesButton.SetActive(false);
			noButton.SetActive(false);
		}
		else if (dialogs[currentDialogIndex].Mode == "Ask")
		{
			dText.text = dialogs[currentDialogIndex].Content;
			nextButton.SetActive(false);
			yesButton.SetActive(true);
			noButton.SetActive(true);
		}
		else if (dialogs[currentDialogIndex].Mode == "Pick")
		{
			dText.text = dialogs[currentDialogIndex].Content;
			nextButton.SetActive(true);
			yesButton.SetActive(false);
			noButton.SetActive(false);

			GameObject item = Instantiate(dialogs[currentDialogIndex].Item);
			item.name = dialogs[currentDialogIndex].Item.name;
			player.GetComponent<PlayerInventory>().PickUpItem(item);
		}

		if (currentItem.GetComponent<SpriteRenderer>())
		{
			itemImage.color = new Color(255, 255, 255, 1);
			itemImage.sprite = currentItem.GetComponent<SpriteRenderer>().sprite;
		}
		else
			itemImage.color = new Color(255, 255, 255, 0);
	}

	public void ContinueDialog()
	{
		if (isdialogActive && (currentDialogIndex <= dialogs.Length - 1))
		{
			currentDialogIndex++;

			//如果currentLine超過dialogLines.Length則不更新dText.text

			if (currentDialogIndex >= dialogs.Length)
			{
				isdialogActive = false;
				currentDialogIndex = 0;
				currentItem.GetComponent<DialogHolder>().EndTalk();
				playerController.EndTalk();
				if (currentItem.CompareTag("Item"))
					player.GetComponent<PlayerInventory>().PickUpItem(currentItem);
			}
			else
			{
				if (dialogs[currentDialogIndex].Mode == "Talk")
				{
					dText.text = dialogs[currentDialogIndex].Content;
					nextButton.SetActive(true);
					yesButton.SetActive(false);
					noButton.SetActive(false);
				}
				else if (dialogs[currentDialogIndex].Mode == "Ask")
				{
					if (askDialogAnswer)
						dText.text = dialogs[currentDialogIndex].Content;
					else {
						dText.text = dialogs[currentDialogIndex].DenyContent;
						currentDialogIndex = dialogs.Length - 1;
					}
					nextButton.SetActive(false);
					yesButton.SetActive(true);
					noButton.SetActive(true);
				}
				else if (dialogs[currentDialogIndex].Mode == "Pick")
				{
					dText.text = dialogs[currentDialogIndex].Content;
					GameObject g = Instantiate(dialogs[currentDialogIndex].Item);
					g.name = dialogs[currentDialogIndex].Item.name;
					player.GetComponent<PlayerInventory>().PickUpItem(g);
					nextButton.SetActive(true);
					yesButton.SetActive(false);
					noButton.SetActive(false);
				}

			}
		}
	}

	public bool IsDialogActive
	{
		get { return isdialogActive; }
	}

	public void ClickYesButton()
	{
		askDialogAnswer = true;
		ContinueDialog();
	}

	public void ClickNoButton()
	{
		askDialogAnswer = false;
		dText.text = dialogs[currentDialogIndex].DenyContent;
		nextButton.SetActive(true);
		yesButton.SetActive(false);
		noButton.SetActive(false);
		currentDialogIndex = dialogs.Length - 1;
	}

	public bool AskDialogAnswer
	{
		get { return askDialogAnswer; }
	}

}