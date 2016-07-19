using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
	public GameObject dBox;
	public Text dText;
	public Dialog[] dialogs;
	public Image answer1;
	public Image answer2;

	private GameObject player;
	private GameObject currentItem;
	private PlayerController playerController;
	private bool isDialogActive;
	private int currentDialogIndex;
	private int askDialogAnswer;

	void Start()
	{
		player = FindObjectOfType<PlayerController>().gameObject;
		playerController = player.GetComponent<PlayerController>();
		answer1.gameObject.SetActive(false);
		answer2.gameObject.SetActive(false);
		isDialogActive = false;
	}

	void Update()
	{
		dBox.SetActive(isDialogActive);

		if (answer1.gameObject.activeSelf && answer2.gameObject.activeSelf)
		{

			Color chosenColor = new Color(1, 1, 1, 0.5f);
			Color notChosenColor = new Color(1, 1, 1, 0);

			if (askDialogAnswer == 1)
			{
				answer1.GetComponent<Image>().color = chosenColor;
				answer2.GetComponent<Image>().color = notChosenColor;
			}
			else {
				answer1.GetComponent<Image>().color = notChosenColor;
				answer2.GetComponent<Image>().color = chosenColor;
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
	}

	public void ShowBox(GameObject gameobject)
	{
		currentItem = gameobject;
		dialogs = currentItem.GetComponent<DialogHolder>().Dialogs;
		playerController.StartTalk();
		isDialogActive = true;
	}

	public void ContinueDialog(GameObject gameobject)
	{
		currentItem = gameobject;
		dialogs = currentItem.GetComponent<DialogHolder>().Dialogs;

		if (!isDialogActive && currentDialogIndex == 0)
		{
			playerController.StartTalk();
			isDialogActive = true;
			ShowDialogByMode();
			currentDialogIndex++;
		}

		else if (isDialogActive && currentDialogIndex <= dialogs.Length)
		{
			if (currentDialogIndex >= dialogs.Length)
			{
				isDialogActive = false;
				currentDialogIndex = 0;
				currentItem.GetComponent<DialogHolder>().TellObjectDialogIsOver();
				playerController.EndTalk();

				if (currentItem.CompareTag("Item"))
					player.GetComponent<PlayerInventory>().PickUpItem(currentItem);
			}
			else
			{
				ShowDialogByMode();
				currentDialogIndex++;
			}
		}
	}

	void ShowDialogByMode()
	{
		if (dialogs[currentDialogIndex].Mode == "Talk")
		{
			dText.text = dialogs[currentDialogIndex].Content;
			answer1.gameObject.SetActive(false);
			answer2.gameObject.SetActive(false);
		}
		else if (dialogs[currentDialogIndex].Mode == "Ask")
		{
			answer1.gameObject.SetActive(true);
			answer2.gameObject.SetActive(true);
			answer1.GetComponentInChildren<Text>().text = dialogs[currentDialogIndex].Answer1;
			answer2.GetComponentInChildren<Text>().text = dialogs[currentDialogIndex].Answer2;
			askDialogAnswer = 1;
		}
		else if (dialogs[currentDialogIndex].Mode == "Pick")
		{
			dText.text = dialogs[currentDialogIndex].Content;
			GameObject g = Instantiate(dialogs[currentDialogIndex].Item);
			g.name = dialogs[currentDialogIndex].Item.name;
			player.GetComponent<PlayerInventory>().PickUpItem(g);
			answer1.gameObject.SetActive(false);
			answer2.gameObject.SetActive(false);
		}
	}

	public bool IsDialogActive
	{
		get { return isDialogActive; }
	}

	//public void ClickNoButton()
	//{
	//	dText.text = dialogs[currentDialogIndex].DenyContent;
	//	answer1.gameObject.SetActive(false);
	//	answer2.gameObject.SetActive(false);
	//	currentDialogIndex = dialogs.Length - 1;
	//}

	public int AskDialogAnswer
	{
		get { return askDialogAnswer; }
	}
}