using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UmbrellaGirlAI : MonoBehaviour {

	public GameObject blackScreen;
	public Sprite image1;
	public Sprite image2;
	public Sprite image3;
	public Sprite image4;

	private GameObject player;
	private SceneLoader sceneLoader;
	private bool isMoving;
	private float movingSpeed = 0.8f;

	private float twinkleRate = 0.05f;
	private float nextTwinkle = 0.0f;

	// Use this for initialization
	void Start () {
		sceneLoader = FindObjectOfType<SceneLoader> ();
		player = FindObjectOfType<PlayerController>().gameObject;
		this.gameObject.SetActive (false);
		blackScreen.SetActive (false);
	}

	// Update is called once per frame
	void Update () {

		if (Time.time > nextTwinkle) {
			nextTwinkle = Time.time + twinkleRate;
			if (this.GetComponent<SpriteRenderer> ().sprite == image1)
				this.GetComponent<SpriteRenderer> ().sprite = image2;
			else if (this.GetComponent<SpriteRenderer> ().sprite == image2)
				this.GetComponent<SpriteRenderer> ().sprite = image3;
			else if (this.GetComponent<SpriteRenderer> ().sprite == image3)
				this.GetComponent<SpriteRenderer> ().sprite = image4;
			else if (this.GetComponent<SpriteRenderer> ().sprite == image4)
				this.GetComponent<SpriteRenderer> ().sprite = image1;
		}

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
