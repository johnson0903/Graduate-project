using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowHintImage : MonoBehaviour
{

	public Sprite hintImage1;
	public Sprite hintImage2;

	private GameObject hintObject;
	private float twinkleRate = 0.3f;
	private float nextTwinkle = 0.0f;

	void Start()
	{
		hintObject = this.transform.GetChild (0).gameObject;
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
