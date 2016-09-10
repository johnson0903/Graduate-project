using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour {
	
	private PlayerController playerController;
	private DialogManager dialogManager;
	private int sceneNum;
	private bool isFadingIn;
	private bool isFadingOut;

	private bool isLoading;

	// Use this for initialization
	void Start () {
		dialogManager = FindObjectOfType<DialogManager> ();
		playerController = FindObjectOfType<PlayerController> ();
		GetComponent<Image> ().color = new Color (1, 1, 1, 0);
	}

	void Update()
	{
		if (isFadingIn)
			GetComponent<Image> ().color = new Color (1, 1, 1, Mathf.Lerp (GetComponent<Image> ().color.a, 1, 0.05f));
		else if (isFadingOut) {
			GetComponent<Image> ().color = new Color (1, 1, 1, Mathf.Lerp (GetComponent<Image> ().color.a, 0, 0.1f));
			if (!dialogManager.IsDialogActive && GetComponent<Image> ().color.a <= 0.01) {
				isFadingOut = false;
				isLoading = false;
				playerController.YouCanMove ();
			}
		}
	}

	public void LoadScene(int whatSceneToLoad) {
		playerController.DontMove ();
		isFadingIn = true;
		isFadingOut = false;
		sceneNum = whatSceneToLoad;
		isLoading = true;
		Invoke ("LoadSceneAfterOneSecond", 1);
	}

	void LoadSceneAfterOneSecond() {
		SceneManager.LoadScene (sceneNum);
		isFadingIn = false;
		isFadingOut = true;
	}

	public bool IsLoading {
		get{ return isLoading; }
	}
}
