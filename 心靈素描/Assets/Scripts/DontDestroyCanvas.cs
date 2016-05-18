using UnityEngine;
using System.Collections;

public class DontDestroyCanvas : MonoBehaviour {

	private static bool isCanvasExist;

	// Use this for initialization
	void Start () {
		if (!isCanvasExist) {
			isCanvasExist = true;
			DontDestroyOnLoad (this.gameObject);
		} else
			Destroy (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
