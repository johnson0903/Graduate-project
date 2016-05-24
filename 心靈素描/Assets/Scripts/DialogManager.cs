using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{

	public GameObject dBox;
	public Text dText;
	public Image itemImage;
	public GameObject player;

	public bool dialogActive;
	public string[] dialogLines;
	public int currentLine;
	private GameObject currentItem;
	private PlayerController playerController;


	void Start ()
	{
		if (player)
			playerController = player.GetComponent<PlayerController> ();
		dBox.SetActive (false);
		dialogActive = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//如果對話的行數超過總對話的行數，結束對話並且重設currentLine為0，將人物結束對話
		if (currentLine >= dialogLines.Length)
		{
			
		}
	}

	public void ShowBox (Sprite itemSprite, GameObject item)
	{
		currentItem = item;
		dialogLines = currentItem.GetComponent<DialogHolder> ().dialogLines;
		playerController.StartTalk ();
		dialogActive = true;
		dBox.SetActive (true);
		dText.text = dialogLines [currentLine];
		itemImage.sprite = itemSprite;
	}

	public void ContinueDialog ()	
	{
		if (dialogActive && (currentLine <= dialogLines.Length - 1))
		{
			currentLine++;
			//如果currentLine超過dialogLines.Length則不更新dText.text
			if (currentLine >= dialogLines.Length) {
				EndDialog ();
				if (currentItem != null && currentItem.CompareTag ("Item")) 
					player.GetComponent<PlayerInventory> ().PickUpItem (currentItem);
			} 
			else
				dText.text = dialogLines [currentLine];
		}
	}

	void EndDialog ()
	{
		dBox.SetActive (false);
		dialogActive = false;
		currentLine = 0;
		playerController.EndTalk ();
	}
}
