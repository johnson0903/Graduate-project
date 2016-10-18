using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {

	public AudioSource[] musicTracks;
	public static bool musicExist;
	public int currentTrack = 0;
	public bool musicCanPlay;

	void Start () {
		if (!musicExist) {
			musicExist = true;
			DontDestroyOnLoad(transform.gameObject);
		} else {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (musicCanPlay) {
			if (!musicTracks [currentTrack].isPlaying) {
				musicTracks [currentTrack].Play ();
			}
		} else {
			musicTracks [currentTrack].Stop ();
		}
	}

	public void SwitchTrack(int newTrack)
	{
		musicTracks [currentTrack].Stop ();
		currentTrack = newTrack;
		Debug.Log (newTrack);
		musicTracks [currentTrack].Play ();
	}
}
