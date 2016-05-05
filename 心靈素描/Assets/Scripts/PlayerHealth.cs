﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour 
{
	private int SAN;
	public Text SAN_text;
	public Image SAN_bar;
	public Image fear;

	// Use this for initialization
	void Awake () 
	{
		SAN = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Color fearDegree = fear.color;
		fearDegree.a = SAN * 0.07f;
		fear.color = fearDegree;
		SAN_bar.fillAmount = SAN * 0.1f;
		SAN_text.text = "SAN: " + SAN;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Enemy" && SAN < 10)
			SAN += 1;
	}
		
}
