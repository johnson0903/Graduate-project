using UnityEngine;
using System.Collections;

public class SymmetryPuzzle : MonoBehaviour {

	public GameObject clock;
	public GameObject umBrellaGirlPaint_Left;
	public GameObject umBrellaGirlPaint_Right;
	public Sprite umbrellaGirlWithBlood_Left;
	public Sprite umbrellaGirlWithBlood_Right;
	public GameObject missionCompleteDialog;
	public GameObject teleportPoint_Left;
	public GameObject teleportPoint_Right;

	private static bool isSymmetryPuzzleOver;

	// Use this for initialization
	void Start () {
		if (isSymmetryPuzzleOver) {
			umBrellaGirlPaint_Left.transform.FindChild("GirlWithUmbrella").GetComponent<SpriteRenderer> ().sprite = umbrellaGirlWithBlood_Left;
			umBrellaGirlPaint_Right.transform.FindChild("GirlWithNoUmbrella").GetComponent<SpriteRenderer> ().sprite = umbrellaGirlWithBlood_Right;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!isSymmetryPuzzleOver &&
			umBrellaGirlPaint_Left.transform.FindChild("GirlWithUmbrella").GetComponent<SpriteRenderer> ().sprite == umbrellaGirlWithBlood_Left &&
			umBrellaGirlPaint_Right.transform.FindChild("GirlWithNoUmbrella").GetComponent<SpriteRenderer> ().sprite == umbrellaGirlWithBlood_Right &&
		    (clock.GetComponent<Corridor_ClockAI> ().Hour == 0 || clock.GetComponent<Corridor_ClockAI> ().Hour == 6)) {
			isSymmetryPuzzleOver = true;
			missionCompleteDialog.GetComponent<Corridor_MissionCompleteDialog> ().MissionComplete ();
			teleportPoint_Left.GetComponent<BoxCollider2D> ().isTrigger = false;
			teleportPoint_Right.GetComponent<BoxCollider2D> ().isTrigger = false;
		}
	}
}
