using UnityEngine;
using System.Collections;

public class LightTwinkle : MonoBehaviour {

	private Light light;
	private float twinkleRate = 0.05f;
	private float nextTwinkle = 0;

	void Start()
	{
		light = this.GetComponent<Light> ();
	}
	// Update is called once per frame
	void Update()
	{	
		if (Time.time > nextTwinkle) {
			nextTwinkle = Time.time + twinkleRate;
			light.intensity = 7 + Random.Range (-1, 1);
		}
	}

}
