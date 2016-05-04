using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour 
{

	public int SAN = 10 ;
	public Image blood;

	// Use this for initialization
	void Awake () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		SAN -= 1;
		blood.fillAmount -= 0.1f;
	}
		
}
