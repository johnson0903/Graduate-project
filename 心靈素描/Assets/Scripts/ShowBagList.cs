using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShowBagList : MonoBehaviour
{
	public GameObject bagList;
	// Use this for initialization
	void Start()
	{
		bagList.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			if (!bagList.activeSelf)
				bagList.SetActive(true);
			else
				bagList.SetActive(false);
		}
	}
}
