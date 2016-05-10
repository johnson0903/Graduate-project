using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TextBoxManager : MonoBehaviour {

	public GameObject dialogBox;
	public Text textBox;
	public TextAsset textfile;
	public Image dialogImage;
	public string[] textLines;
	public int currentLine;
	public int endLine;

	void Start () {	

		if (textfile != null) {
			textLines = textfile.text.Split ('\n');
		}

		if (endLine == 0) {
			endLine = textLines.Length - 1;
		}
			
	}

	void Update (){
		if (currentLine <= endLine) {
			textBox.text = textLines [currentLine];
		}

		if (Input.GetKeyDown (KeyCode.Mouse0)){
			if (currentLine <= endLine)
				currentLine += 1;
		}

		if (currentLine > endLine) {
			dialogBox.SetActive (false);
		}
	}
}
