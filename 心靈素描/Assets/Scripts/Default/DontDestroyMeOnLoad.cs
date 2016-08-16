using UnityEngine;
using System.Collections;

public class DontDestroyMeOnLoad : MonoBehaviour {

	private static bool isPlayerExist;

	// Use this for initialization
	void Start () {
		if (!isPlayerExist) {
			isPlayerExist = true;
			DontDestroyOnLoad (this.gameObject);
		} else
			Destroy (this.gameObject);
	}
}
