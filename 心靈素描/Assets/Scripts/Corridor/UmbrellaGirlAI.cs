using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UmbrellaGirlAI : MonoBehaviour {

	public GameObject blackScreen;

	private GameObject player;
	private SceneLoader sceneLoader;
	private bool isMoving;
	private float movingSpeed = 2.4f;

	// Use this for initialization
	void Start () {
		sceneLoader = FindObjectOfType<SceneLoader> ();
		player = FindObjectOfType<PlayerController>().gameObject;
		this.gameObject.SetActive (false);
		blackScreen.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (this.transform.position.x < player.transform.position.x)
			this.transform.localScale = new Vector3 (3.5f, 3.5f, 1);
		else if (this.transform.position.x > player.transform.position.x)
			this.transform.localScale = new Vector3 (-3.5f, 3.5f, 1);

		if (isMoving) {
			if (this.transform.position.x < player.transform.position.x)
				this.transform.position = new Vector3 (this.transform.position.x + movingSpeed, this.transform.position.y, this.transform.position.z);
			else if (this.transform.position.x > player.transform.position.x)
				this.transform.position = new Vector3 (this.transform.position.x - movingSpeed, this.transform.position.y, this.transform.position.z);
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (isMoving && other.CompareTag ("Player")) {
			isMoving = false;
			ShowBlackScreen ();
		}
	}

	void ShowBlackScreen() {
		blackScreen.SetActive (true);
		Invoke ("ChangeScene", 0.15f);
		Invoke ("UnlockBlackScreen", 0.3f);
	}

	void ChangeScene() {
		sceneLoader.LoadSceneAndMovePlayerQuickly (1, new Vector3 (28, player.transform.position.y, 0), -1);
	}

	void UnlockBlackScreen() {
		blackScreen.SetActive (false);
		this.gameObject.SetActive (false);
	}
		
	public void Move() {
		isMoving = true;
	}
				
}
