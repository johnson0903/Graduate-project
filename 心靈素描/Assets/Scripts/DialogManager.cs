using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

	public GameObject dBox;
	public Text dText;
	public Image itemImage;
	public GameObject player;

	public bool dialogActive;
	public string[] dialogLines;
	public int currentLine;

	private PlayerController playerController;
	void Start () {
		if (player)
			playerController = player.GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {

		//如果正在對話，按下滑鼠要繼續下一行對話，更新對話框內容顯示currentLine
		if (dialogActive && Input.GetMouseButtonDown(0)) {	
			currentLine++;
			if(currentLine <= dialogLines.Length - 1)
				dText.text = dialogLines [currentLine];
		}

		//如果對話的行數超過總對話的行數，結束對話並且重設currentLine為0，將人物結束對話
		if (currentLine >= dialogLines.Length) {
			dBox.SetActive (false);
			dialogActive = false;
			currentLine = -1;
			playerController.EndTalk ();
		}
	}

	//顯示對話框
	public void ShowBox() {
		playerController.StartTalk ();
		dialogActive = true;
		dBox.SetActive (true);
		itemImage.color = new Color (255, 255, 255, 0);
		dText.text = dialogLines[currentLine];
	}

	public void ShowBox(Sprite itemSprite){
		playerController.StartTalk ();
		dialogActive = true;
		dBox.SetActive (true);
		itemImage.color = new Color (255, 255, 255, 1);
		dText.text = dialogLines[currentLine];
		itemImage.sprite = itemSprite;
	}
}
