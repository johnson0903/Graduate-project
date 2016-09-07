using UnityEngine;
using System.Collections;

public class AudioSwitcher : MonoBehaviour {

	public AudioClip[] audioClips;

	private AudioSource audiosource;

	// Use this for initialization
	void Start () {
		audiosource = GetComponent<AudioSource> ();
	}

	public void playSoundEffect(int i){
//		audiosource.clip = audioClips[i];
//		audiosource.Play();
//		Debug.Log(i);
	}
}
