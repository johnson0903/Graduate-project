using UnityEngine;
using System.Collections;

public class FourCrossPuzzle : MonoBehaviour {

	public GameObject happyCross;
	public GameObject angryCross;
	public GameObject sadCross;
	public GameObject boringCross;
	public GameObject happyMask;
	public GameObject angryMask;
	public GameObject sadMask;
	public GameObject boringMask;
	public GameObject missionCompleteDialog;
	public GameObject oldBackGround;
	public Sprite newBackGroundImage;
	public GameObject door;

	private static bool isFourCrossPuzzleOver;

	// Use this for initialization
	void Start () {
		if (isFourCrossPuzzleOver) {
			happyCross.GetComponent<FourCrossAI> ().IsPuzzleOver = true;
			angryCross.GetComponent<FourCrossAI> ().IsPuzzleOver = true;
			sadCross.GetComponent<FourCrossAI> ().IsPuzzleOver = true;
			boringCross.GetComponent<FourCrossAI> ().IsPuzzleOver = true;
			angryCross.GetComponent<FourCrossAI> ().WearMask (angryMask);
			sadCross.GetComponent<FourCrossAI> ().WearMask (sadMask);
			boringCross.GetComponent<FourCrossAI> ().WearMask (boringMask);
			oldBackGround.GetComponent<SpriteRenderer> ().sprite = newBackGroundImage;
			door.GetComponent<FourCrossPaint_DoorAI> ().OpenDoor ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if (!isFourCrossPuzzleOver) {
			if (happyCross.GetComponent<FourCrossAI> ().CurrentMask != null && angryCross.GetComponent<FourCrossAI> ().CurrentMask != null &&
				sadCross.GetComponent<FourCrossAI> ().CurrentMask != null && boringCross.GetComponent<FourCrossAI> ().CurrentMask != null && 
				happyCross.GetComponent<FourCrossAI> ().CurrentMask.name == "HappyMask" && angryCross.GetComponent<FourCrossAI> ().CurrentMask.name == "AngryMask" &&
				sadCross.GetComponent<FourCrossAI> ().CurrentMask.name == "SadMask" && boringCross.GetComponent<FourCrossAI> ().CurrentMask.name == "BoringMask") {

				isFourCrossPuzzleOver = true;
				missionCompleteDialog.GetComponent<FourCrossPaint_MissionCompleteDialog> ().MissionComplete ();
				happyCross.GetComponent<FourCrossAI> ().IsPuzzleOver = true;
				angryCross.GetComponent<FourCrossAI> ().IsPuzzleOver = true;
				sadCross.GetComponent<FourCrossAI> ().IsPuzzleOver = true;
				boringCross.GetComponent<FourCrossAI> ().IsPuzzleOver = true;
				door.GetComponent<FourCrossPaint_DoorAI> ().OpenDoor ();
			}
		}
			
	}
}
