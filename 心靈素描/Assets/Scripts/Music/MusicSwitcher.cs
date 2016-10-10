using UnityEngine;
using System.Collections;

public class MusicSwitcher : MonoBehaviour {

	private MusicController theMC;

	public int newTrack;
	public bool switchOnStart;

	private static bool isPlaying;

	void Start () {
		theMC = FindObjectOfType<MusicController> ();

//		if (switchOnStart) {
//			theMC.SwitchTrack (newTrack);
//		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player" && gameObject.activeSelf && !isPlaying) {
			theMC.SwitchTrack (newTrack);
			isPlaying = true;
			gameObject.SetActive (false);
		}
	}
}
