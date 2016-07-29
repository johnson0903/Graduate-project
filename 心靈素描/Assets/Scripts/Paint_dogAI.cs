using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class Paint_dogAI : MonoBehaviour {

	private GameObject player;
	private DialogHolder dialogHolder;
	private static bool ChangeSceneByDogPaint;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ().gameObject;
		dialogHolder = this.GetComponent<DialogHolder> ();
		this.GetComponent<DialogHolder> ().DialogOverEvent += OnDialogOver;

		if (ChangeSceneByDogPaint) {	
			player.transform.position = new Vector3 (this.transform.position.x, player.transform.position.y, player.transform.position.z);
			ChangeSceneByDogPaint = false;
		}
	}

	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene ().buildIndex == 0)
			dialogHolder.Dialogs = new Dialog[] {
				dialogHolder.TalkDialog ("一幅畫著狗狗的畫"),
				dialogHolder.TalkDialog ("喔喔喔喔喔喔....!")
			};
		else
			dialogHolder.Dialogs = new Dialog[] {
				dialogHolder.TalkDialog ("要回去了嗎"),
				dialogHolder.AskDialog ("回去", "待著", new Dialog[] {
					dialogHolder.TalkDialog ("再調查一下好了")
				}), dialogHolder.TalkDialog ("回去囉"),
			};
	}


	void OnDialogOver (object sender, EventArgs e)
	{
		ChangeSceneByDogPaint = true;
		if (SceneManager.GetActiveScene ().buildIndex == 0)
			SceneManager.LoadScene (2);
		else if (dialogHolder.AskDialogAnswer == 1) {
			SceneManager.LoadScene (0);
		}
	}
}
