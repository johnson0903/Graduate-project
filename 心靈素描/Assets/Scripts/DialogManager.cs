using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
	public GameObject dBox;
	public Text dText;
	public Image itemImage;
	public Dialog[] dialogs;

	private GameObject player;
	private PlayerController playerController;
	private bool dialogActive;
	private int currentLine;
	private GameObject currentItem;

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
		dText.text = dialogs [currentLine].Content;
		if (currentItem.GetComponent<SpriteRenderer> ()) {
			itemImage.color = new Color(255, 255, 255, 1);
			itemImage.sprite = currentItem.GetComponent<SpriteRenderer> ().sprite;
		}
		else 
			itemImage.color = new Color(255, 255, 255, 0);		
	}

	public void ContinueDialog ()	
	{
		if (dialogActive && (currentLine <= dialogs.Length - 1)) {
			currentLine++;
			//如果currentLine超過dialogLines.Length則不更新dText.text
			if (currentLine >= dialogs.Length) {
				dialogActive = false;
				currentLine = 0;
				currentItem.GetComponent<DialogHolder> ().EndTalk ();
				playerController.EndTalk ();
				if (currentItem.CompareTag ("Item")) {
					player.GetComponent<PlayerInventory> ().PickUpItem (currentItem);
				}
			} else
				dText.text = dialogs [currentLine].Content;
		}
	}

	public bool IsDialogActive {
		get{ return dialogActive; }
	}

}
