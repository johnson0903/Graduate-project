using UnityEngine;
using System.Collections;

public class UmbrellaGirlAI : MonoBehaviour {

	private bool isMoving;
	private bool isOver;

	// Use this for initialization
	void Start () {
		this.gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (isMoving && this.transform.position.x < 70)
			this.transform.position = new Vector3 (this.transform.position.x + 0.3f, this.transform.position.y, this.transform.position.z);

		if (this.transform.position.x >= 50)
			isOver = true;
	}

	public void Move() {
		isMoving = true;
	}

	public bool IsOver {
		get{ return isOver; }
	}

}
