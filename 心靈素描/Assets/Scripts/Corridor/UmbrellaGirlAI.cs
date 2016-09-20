using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UmbrellaGirlAI : MonoBehaviour {

	private GameObject player;
	private SceneLoader sceneLoader;
	private bool isMoving;
	private bool isOver;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>().gameObject;
		this.gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		sceneLoader = FindObjectOfType<SceneLoader> ();

		if (this.transform.position.x < player.transform.position.x)
			this.transform.localScale = new Vector3 (3.5f, 3.5f, 1);
		else if (this.transform.position.x > player.transform.position.x)
			this.transform.localScale = new Vector3 (-3.5f, 3.5f, 1);

		if (isMoving) {
			if (this.transform.position.x < player.transform.position.x)
				this.transform.position = new Vector3 (this.transform.position.x + 1.2f, this.transform.position.y, this.transform.position.z);
			else if (this.transform.position.x > player.transform.position.x)
				this.transform.position = new Vector3 (this.transform.position.x - 1.2f, this.transform.position.y, this.transform.position.z);
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (isMoving && other.CompareTag ("Player")) {
			sceneLoader.LoadSceneAndMovePlayer (0, new Vector3(26, other.transform.position.y, 0), -1);
			isMoving = false;
			isOver = true;
		}
	}


	public void Move() {
		isMoving = true;
	}

	public bool IsOver {
		get{ return isOver; }
	}
		
}
