using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ItemData : MonoBehaviour {

	public string name;
	public string description;
	public bool changeSceneMode;
	public int whatSceneToGo;

	public void UseItem ()
	{
		if (changeSceneMode)
			SceneManager.LoadScene (whatSceneToGo);
	}

	public bool CanBeUsed {
		get { return changeSceneMode; }
	}
}
