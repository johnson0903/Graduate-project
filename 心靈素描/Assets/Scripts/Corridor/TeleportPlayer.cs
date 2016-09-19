using UnityEngine;
using System.Collections;

public class TeleportPlayer : MonoBehaviour {

	public float teleportX;
	public bool isChangeSceneMode;
	public int whatSceneToChange;

	private SceneLoader sceneLoader;
	private bool isTeleporting;

	void Start () {
		sceneLoader = FindObjectOfType<SceneLoader> ();
	}

	void OnTriggerStay2D (Collider2D other)
	{
		if (other.CompareTag ("Player") && !isTeleporting) {
			isTeleporting = true;
			if (isChangeSceneMode) {
				if (teleportX > 0)
					sceneLoader.LoadSceneAndMovePlayer (whatSceneToChange, new Vector3 (teleportX, other.transform.position.y, 0), -1);
				else
					sceneLoader.LoadSceneAndMovePlayer (whatSceneToChange, new Vector3 (teleportX, other.transform.position.y, 0), 1);
			} else
				other.transform.position = new Vector3 (teleportX, other.transform.position.y, other.transform.position.z);
		}
	}

	
}
			
		


 