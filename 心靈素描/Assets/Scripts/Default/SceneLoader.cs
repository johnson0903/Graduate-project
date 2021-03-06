﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour {
	
	private GameObject player;
	private DialogManager dialogManager;

	private int sceneNum;
	private Vector3 playerPosition;
	private int playerScale;
	private bool isFadingIn;
	private bool isFadingOut;
	private bool isLoading;

	// Use this for initialization
	void Start () {
		dialogManager = FindObjectOfType<DialogManager> ();
		player = FindObjectOfType<PlayerController> ().gameObject;
		GetComponent<Image> ().color = new Color (1, 1, 1, 1);
		isLoading = true;
		isFadingIn = false;
		isFadingOut = true;
	}

	void Update()
	{
		if (isFadingIn) {
			GetComponent<Image> ().color = new Color (1, 1, 1, Mathf.Lerp (GetComponent<Image> ().color.a, 1, 0.05f));
			if (!dialogManager.IsDialogActive && GetComponent<Image> ().color.a >= 0.99f)
				LoadScene ();
		}
		else if (isFadingOut) {
			GetComponent<Image> ().color = new Color (1, 1, 1, Mathf.Lerp (GetComponent<Image> ().color.a, 0, 0.1f));
			if (!dialogManager.IsDialogActive && GetComponent<Image> ().color.a <= 0.01f) {
				isFadingOut = false;
				isLoading = false;
				player.GetComponent<PlayerController> ().YouCanMove ();
			}
		}
	}

	public void LoadSceneAndMovePlayer(int whatSceneToLoad, Vector3 whereToMove, int whereToSee) {
		player.GetComponent<PlayerController> ().DontMove ();
		isFadingIn = true;
		isFadingOut = false;
		isLoading = true;
		sceneNum = whatSceneToLoad;
		playerPosition = whereToMove;
		playerScale = whereToSee;
	}

	public void LoadSceneAndMovePlayerQuickly(int whatSceneToLoad, Vector3 whereToMove, int whereToSee) {
		player.GetComponent<PlayerController> ().DontMove ();
		sceneNum = whatSceneToLoad;
		playerPosition = whereToMove;
		playerScale = whereToSee;
		LoadScene ();
	}

	void LoadScene() {
		SceneManager.LoadScene (sceneNum);
		player.transform.position = playerPosition;
			
		if (sceneNum == 4 || sceneNum == 5)
			player.GetComponent<SpriteRenderer> ().color = new Color (0.7f, 0.7f, 0.7f, 1);
		else if (sceneNum == 6)
			player.GetComponent<SpriteRenderer> ().color = new Color (0.5f, 0.5f, 0.5f, 1);
		else
			player.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1);

		if (playerScale == 1)
			player.GetComponent<Flip> ().FlipRight ();
		else
			player.GetComponent<Flip> ().FlipLeft ();
		
		isFadingIn = false;
		isFadingOut = true;
	}

	public bool IsLoading {
		get{ return isLoading; }
	}

}
