using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowHintImage : MonoBehaviour
{
	private GameObject hintObject;
	private Sprite hintImage1;
	private Sprite hintImage2;
	private float twinkleRate = 0.3f;
	private float nextTwinkle = 0.0f;

	void Start()
	{
		hintImage1 = Resources.Load <Sprite> ("hint_eye1");
		hintImage2 = Resources.Load <Sprite> ("hint_eye2");
		hintObject = this.transform.GetChild (0).gameObject;
		hintObject.SetActive (false);
	}
	// Update is called once per frame
	void Update()
	{
		if (this.GetComponent<DialogHolder>().IsPlayerInRange)
		{
			hintObject.SetActive(true);
			if (Time.time > nextTwinkle)
			{
				nextTwinkle = Time.time + twinkleRate;
				if (hintObject.GetComponent<SpriteRenderer>().sprite == hintImage1)
					hintObject.GetComponent<SpriteRenderer>().sprite = hintImage2;
				else
					hintObject.GetComponent<SpriteRenderer>().sprite = hintImage1;
			}
		}
		else
			hintObject.SetActive(false);
	}
}
