using UnityEngine;
using System.Collections;

public class Twinkle : MonoBehaviour {

	public Material twoDLight;
	public Material normal;

	private SpriteRenderer spriteRenderer;
	private float twinkleRate = 0.5f;
	private float nextTwinkle = 0;
	private bool isNormal;

	void Start()
	{
		spriteRenderer = this.GetComponent<SpriteRenderer> ();
	}
	// Update is called once per frame
	void Update()
	{
		if (Time.time > nextTwinkle) {
			nextTwinkle = Time.time + twinkleRate;
			if (isNormal) {
				isNormal = false;
				spriteRenderer.material = twoDLight;
			} else {
				isNormal = true;
				spriteRenderer.material = normal;
			}
		
		}
	}

}
