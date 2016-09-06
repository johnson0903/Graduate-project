using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowHintImage : MonoBehaviour
{
	private GameObject hintObject;
	private Sprite hintImage_Black1;
	private Sprite hintImage_Black2;
	private Sprite hintImage_White1;
	private Sprite hintImage_White2;
	private float twinkleRate = 0.3f;
	private float nextTwinkle = 0.0f;

	void Start()
	{
		hintImage_Black1 = Resources.Load <Sprite> ("Hint_Eye_Black1");
		hintImage_Black2 = Resources.Load <Sprite> ("Hint_Eye_Black2");
		hintImage_White1 = Resources.Load <Sprite> ("Hint_Eye_White1");
		hintImage_White2 = Resources.Load <Sprite> ("Hint_Eye_White2");
		hintObject = this.transform.GetChild (0).gameObject;
		hintObject.SetActive (false);
	}
	// Update is called once per frame
	void Update()
	{
		if (this.GetComponent<DialogHolder> ().IsPlayerInRange) {
			hintObject.SetActive (true);
			if (Time.time > nextTwinkle) {
				nextTwinkle = Time.time + twinkleRate;
				if (hintObject.name == "Hint_Eye_Black") {
					if (hintObject.GetComponent<SpriteRenderer> ().sprite == hintImage_Black1)
						hintObject.GetComponent<SpriteRenderer> ().sprite = hintImage_Black2;
					else
						hintObject.GetComponent<SpriteRenderer> ().sprite = hintImage_Black1;
				} else {
					if (hintObject.GetComponent<SpriteRenderer> ().sprite == hintImage_White1)
						hintObject.GetComponent<SpriteRenderer> ().sprite = hintImage_White2;
					else
						hintObject.GetComponent<SpriteRenderer> ().sprite = hintImage_White1;
				}
			}
		}
		else
			hintObject.SetActive(false);
	}
}
