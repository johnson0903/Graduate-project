using UnityEngine;
using System.Collections;

public class SymmetryPuzzle : MonoBehaviour {

	public GameObject clock;
	public GameObject umBrellaGirl_Left;
	public GameObject umBrellaGirl_Right;
	public Sprite umbrellaGirlWithBlood;
	public GameObject missionCompleteDialog;
	public GameObject teleportPoint_Left;
	public GameObject teleportPoint_Right;

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
		if (!isSymmetryPuzzleOver &&
			umBrellaGirl_Left.transform.FindChild("GirlWithUmbrella").GetComponent<SpriteRenderer> ().sprite == umbrellaGirlWithBlood &&
			umBrellaGirl_Right.transform.FindChild("GirlWithNoUmbrella").GetComponent<SpriteRenderer> ().sprite == umbrellaGirlWithBlood &&
		    (clock.GetComponent<Corridor_ClockAI> ().Hour == 0 || clock.GetComponent<Corridor_ClockAI> ().Hour == 6)) {
			isSymmetryPuzzleOver = true;
			missionCompleteDialog.GetComponent<Corridor_MissionCompleteDialog> ().MissionComplete ();
			teleportPoint_Left.GetComponent<BoxCollider2D> ().isTrigger = false;
			teleportPoint_Right.GetComponent<BoxCollider2D> ().isTrigger = false;
		}
	}
}
