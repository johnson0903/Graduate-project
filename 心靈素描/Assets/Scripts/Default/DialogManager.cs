using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
	public GameObject dBox;
	public Text dText;
	public Dialog[] dialogs;
	public GameObject answer1;
	public GameObject answer2;
	public GameObject pickUpItemImage;

	private Dialog[] originalDialogs;
	private GameObject player;
	private GameObject talkingObeject;
	private PlayerController playerController;
	private bool isDialogActive;
	private int currentDialogIndex;
	private int askDialogAnswer;
	private int originalDialogIndex;

	void Start()
	{
		player = FindObjectOfType<PlayerController>().gameObject;
		playerController = player.GetComponent<PlayerController>();
		answer1.SetActive(false);
		answer2.SetActive(false);
		pickUpItemImage.SetActive (false);
		isDialogActive = false;
	}

	void Update()
	{
		dBox.SetActive(isDialogActive);

		if (answer1.activeSelf && answer2.gameObject.activeSelf)
			ShowAnswerMenu();
	}

	void ShowAnswerMenu()
	{
		Color chosenColor = new Color(1, 1, 1, 0.5f);
		Color notChosenColor = new Color(1, 1, 1, 0);

		if (askDialogAnswer == 1)
		{
			answer1.GetComponent<Image>().color = chosenColor;
			answer2.GetComponent<Image>().color = notChosenColor;
			answer1.transform.FindChild ("Pointer").gameObject.SetActive (true);
			answer2.transform.FindChild ("Pointer").gameObject.SetActive (false);
			dialogs = originalDialogs;
			currentDialogIndex = originalDialogIndex + 1;
		}
		else 
		{
			answer1.GetComponent<Image>().color = notChosenColor;
			answer2.GetComponent<Image>().color = chosenColor;
			answer1.transform.FindChild ("Pointer").gameObject.SetActive (false);
			answer2.transform.FindChild ("Pointer").gameObject.SetActive (true);
			dialogs = originalDialogs[originalDialogIndex].Answer2_Dialogs;
			currentDialogIndex = 0;
		}

		if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) ||
		   Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
		{
			if (askDialogAnswer == 1)
				askDialogAnswer = 2;
			else
				askDialogAnswer = 1;
		}
	}

	void ShowDialogByMode()
	{
		if (dialogs[currentDialogIndex].Mode == "Talk")
		{
			dText.text = dialogs[currentDialogIndex].Content;
			answer1.SetActive(false);
			answer2.SetActive(false);
			pickUpItemImage.SetActive (false);
		}
		else if (dialogs[currentDialogIndex].Mode == "Ask")
		{
			originalDialogs = dialogs;
			originalDialogIndex = currentDialogIndex;
			askDialogAnswer = 1;
			answer1.SetActive(true);
			answer2.SetActive(true);
			pickUpItemImage.SetActive (false);
			answer1.GetComponentInChildren<Text>().text = dialogs[currentDialogIndex].Answer1;
			answer2.GetComponentInChildren<Text>().text = dialogs[currentDialogIndex].Answer2;
		}
		else if (dialogs[currentDialogIndex].Mode == "Pick")
		{
			dText.text = dialogs[currentDialogIndex].Content;
			GameObject g = Instantiate(dialogs[currentDialogIndex].Item);
			g.name = dialogs[currentDialogIndex].Item.name;
			player.GetComponent<PlayerInventory>().PickUpItem(g);
			answer1.SetActive(false);
			answer2.SetActive(false);
			pickUpItemImage.SetActive (true);
			pickUpItemImage.transform.GetChild(0).GetComponent<Image> ().sprite = dialogs [currentDialogIndex].Item.GetComponent<SpriteRenderer> ().sprite;
		}
	}

	public void ContinueDialog(GameObject gameobject)
	{
		if (!isDialogActive && currentDialogIndex == 0)
		{
			talkingObeject = gameobject;
			dialogs = talkingObeject.GetComponent<DialogHolder>().Dialogs;
			playerController.DontMove();
			isDialogActive = true;
			askDialogAnswer = 0;
			ShowDialogByMode();
			currentDialogIndex++;
		}

		else if (isDialogActive && currentDialogIndex <= dialogs.Length)
		{
			if (currentDialogIndex >= dialogs.Length)
			{
				isDialogActive = false;
				currentDialogIndex = 0;
				talkingObeject.GetComponent<DialogHolder>().TellObjectDialogIsOver();
				playerController.YouCanMove();
			}
			else
			{
				ShowDialogByMode();
				currentDialogIndex++;
			}
		}
	}

	public bool IsDialogActive
	{
		get { return isDialogActive; }
	}

	public int AskDialogAnswer
	{
		get { return askDialogAnswer; }
	}
}