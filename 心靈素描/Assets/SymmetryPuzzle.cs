using UnityEngine;
using System.Collections;

public class SymmetryPuzzle : MonoBehaviour {

	public GameObject clock;
	public GameObject umBrellaGirl_Left;
	public GameObject umBrellaGirl_Right;
	public Sprite umbrellaGirlWithBlood;

	private static bool isSymmetryPuzzleOver;

	// Use this for initialization
	void Start () {
		if (isSymmetryPuzzleOver) {
			umBrellaGirl_Left.transform.FindChild("GirlWithUmbrella").GetComponent<SpriteRenderer> ().sprite = umbrellaGirlWithBlood;
			umBrellaGirl_Right.transform.FindChild("GirlWithNoUmbrella").GetComponent<SpriteRenderer> ().sprite = umbrellaGirlWithBlood;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (umBrellaGirl_Left.transform.FindChild("GirlWithUmbrella").GetComponent<SpriteRenderer> ().sprite == umbrellaGirlWithBlood &&
			umBrellaGirl_Right.transform.FindChild("GirlWithNoUmbrella").GetComponent<SpriteRenderer> ().sprite == umbrellaGirlWithBlood &&
		    (clock.GetComponent<Corridor_ClockAI> ().Hour == 0 || clock.GetComponent<Corridor_ClockAI> ().Hour == 6)) {
			isSymmetryPuzzleOver = true;
			Debug.Log ("66666");
		}
	}
}
