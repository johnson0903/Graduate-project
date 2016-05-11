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

	private PlayerController playerController;

	void Start ()
	{
		if (player)
			playerController = player.GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//如果對話的行數超過總對話的行數，結束對話並且重設currentLine為0，將人物結束對話
		if (currentLine >= dialogLines.Length) {
			dBox.SetActive (false);
			dialogActive = false;
			currentLine = 0;
			playerController.EndTalk ();
		}
	}

	//顯示對話框
	public void ShowBox ()
	{
		playerController.StartTalk ();
		dialogActive = true;
		dBox.SetActive (true);
		itemImage.color = new Color (255, 255, 255, 0);
		dText.text = dialogLines [currentLine];
	}

	public void ShowBox (Sprite itemSprite)
	{
		playerController.StartTalk ();
		dialogActive = true;
		dBox.SetActive (true);
		itemImage.color = new Color (255, 255, 255, 1);
		dText.text = dialogLines [currentLine];
		itemImage.sprite = itemSprite;
	}

	public void ContinueDialog ()
	{
		if (dialogActive && (currentLine <= dialogLines.Length - 1)) {
			currentLine++;

			//如果currentLine超過dialogLines.Length則不更新dText.text
			if (currentLine == dialogLines.Length)
				return;
			
			dText.text = dialogLines [currentLine];
		}
	}
}
