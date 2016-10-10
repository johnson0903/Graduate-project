using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour {

	public GameObject mainScene;
	public GameObject slideShow1;
	public GameObject slideShow2;
	public Image dark;

	private GameObject startGameButton;
	private GameObject settingGameButton;
	private GameObject selectedButtonImage;
	private GameObject gameSettingImage;
	private int selectedButtonCount;
	private int currentSceneCount;

	bool isFadingIn;
	bool isFadingOut;

	// Use this for initialization
	void Start () {
		startGameButton = mainScene.transform.FindChild ("StartGameButton").gameObject;
		settingGameButton = mainScene.transform.FindChild ("SettingGameButton").gameObject;
		selectedButtonImage = mainScene.transform.FindChild ("SelectedButtonImage").gameObject;
		gameSettingImage = mainScene.transform.FindChild ("GameSettingImage").gameObject;
		selectedButtonCount = 0;
		currentSceneCount = 0;

		gameSettingImage.SetActive (false);
		slideShow1.SetActive (false);
		slideShow2.SetActive (false);
		isFadingIn = false;
		isFadingOut = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentSceneCount == 0)
			SelectButton ();
		else if (currentSceneCount == 1)
			ChangeImageByFade (mainScene, slideShow1);
		else if (currentSceneCount == 2)
			ChangeImageByFade (slideShow1, slideShow2);	
		else if (currentSceneCount == 3)
			ChangeSceneByFade (1);	

		if (isFadingIn)
			dark.color = new Color (1, 1, 1, Mathf.Lerp (dark.color.a, 1, 0.05f));
		else if (isFadingOut) {
			dark.color = new Color (1, 1, 1, Mathf.Lerp (dark.color.a, 0, 0.05f));
			if (dark.color.a <= 0.05) 
				isFadingOut = false;
		} 

	}

	void SelectButton() {
		if (selectedButtonCount == 0)
			selectedButtonImage.GetComponent<Image>().rectTransform.anchoredPosition = Vector2.Lerp (selectedButtonImage.GetComponent<Image>().rectTransform.anchoredPosition, new Vector2 (0, startGameButton.GetComponent<Text>().rectTransform.anchoredPosition.y), 0.2f);
		else
			selectedButtonImage.GetComponent<Image>().rectTransform.anchoredPosition = Vector2.Lerp (selectedButtonImage.GetComponent<Image>().rectTransform.anchoredPosition, new Vector2 (0, settingGameButton.GetComponent<Text>().rectTransform.anchoredPosition.y), 0.2f);
		
		if (!gameSettingImage.activeSelf) {
			if ((Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W)) && selectedButtonCount == 1)
				selectedButtonCount -= 1;
			else if ((Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.S)) && selectedButtonCount == 0)
				selectedButtonCount += 1;
			if (Input.GetKeyDown (KeyCode.Space)) {
				if (selectedButtonCount == 0) {
					isFadingIn = true;
					currentSceneCount++;
				} else
					gameSettingImage.SetActive (true);
			}
		} else if (Input.GetKeyDown (KeyCode.Space))
			gameSettingImage.SetActive (false);

	}

	void ChangeImageByFade(GameObject currentImage, GameObject nextImage){
		if (dark.color.a >= 0.99) {
			isFadingIn = false;
			isFadingOut = true;
			currentImage.SetActive (false);
			nextImage.SetActive (true);
		} else if (dark.color.a <= 0.05 && Input.GetKeyDown (KeyCode.Space)) {
			isFadingIn = true;
			currentSceneCount++;
		}
	}

	void ChangeSceneByFade(int whereToGo){
		if (dark.color.a >= 0.99) 
			SceneManager.LoadScene (whereToGo);
	}
}
