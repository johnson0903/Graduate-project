using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;

public class Bedroom_BathroomDoorAI : MonoBehaviour {

	private GameObject player;
	private DialogHolder dialogHolder;
	private SceneLoader sceneLoader;
	private const int DOOR_OPEN = 0;
	private const int DOOR_CLOSED = 1;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ().gameObject;
		dialogHolder = this.GetComponent<DialogHolder> ();
		sceneLoader = FindObjectOfType<SceneLoader> ();
		this.GetComponent<DialogHolder> ().DialogOverEvent += OnDialogOver;
	}

	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene().buildIndex == 1)
			dialogHolder.Dialogs = new List<Dialog> { dialogHolder.PlaySoundDialog("通往廁所", DOOR_OPEN) };
		else
			dialogHolder.Dialogs = new List<Dialog> { dialogHolder.PlaySoundDialog("通往臥室", DOOR_OPEN) };
	}

	void OnDialogOver (object sender, EventArgs e)
	{
		if (SceneManager.GetActiveScene().buildIndex == 1)
			sceneLoader.LoadSceneAndMovePlayer(2, new Vector3(17, player.transform.position.y, 0), -1);
		else
			sceneLoader.LoadSceneAndMovePlayer(1, new Vector3(18.8f, player.transform.position.y, 0), 1);
	}

	public IEnumerator WaitForSeconds(int waitTime)
	{
		yield return new WaitForSeconds(waitTime);
	}
}
