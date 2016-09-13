using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UmbrellaGirlAI : MonoBehaviour {

	private SceneLoader sceneLoader;
	private bool isMoving;
	private bool isOver;

	// Use this for initialization
	void Start () {
		this.gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		sceneLoader = FindObjectOfType<SceneLoader> ();

		if (isMoving && this.transform.position.x < 70)
			this.transform.position = new Vector3 (this.transform.position.x + 0.3f, this.transform.position.y, this.transform.position.z);

		if (this.transform.position.x >= 50)
			isOver = true;
	}

	void OnTriggerStay2D(Collider2D other) {
		if (isMoving && other.CompareTag ("Player")) {
			sceneLoader.LoadSceneAndMovePlayer (0, new Vector3(26, other.transform.position.y, 0), -1);
			isMoving = false;
		}
	}


	public void Move() {
		isMoving = true;
	}

	public bool IsOver {
		get{ return isOver; }
	}
		
}
