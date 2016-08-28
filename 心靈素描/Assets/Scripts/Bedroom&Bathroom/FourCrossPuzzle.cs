using UnityEngine;
using System.Collections;

public class FourCrossPuzzle : MonoBehaviour {

	public GameObject box;
	public GameObject happyCross;
	public GameObject angryCross;
	public GameObject sadCross;
	public GameObject boringCross;
	public GameObject ironBox;
	public GameObject missionCompleteDialog;

	private static bool puzzleTime;

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		
		if (!puzzleTime && box.GetComponent<FourCrossPaint_BoxAI> ().AreFourMasksTaken) {
			happyCross.GetComponent<FourCrossAI> ().PuzzleTime = true;
			angryCross.GetComponent<FourCrossAI> ().PuzzleTime = true;
			sadCross.GetComponent<FourCrossAI> ().PuzzleTime = true;
			boringCross.GetComponent<FourCrossAI> ().PuzzleTime = true;
		}

		if (!puzzleTime &&
			happyCross.GetComponent<FourCrossAI> ().currentMaskName == "HappyMask" && angryCross.GetComponent<FourCrossAI> ().currentMaskName == "AngryMask" &&
			sadCross.GetComponent<FourCrossAI> ().currentMaskName == "SadMask" && boringCross.GetComponent<FourCrossAI> ().currentMaskName == "BoringMask") {

			puzzleTime = true;
			ironBox.GetComponent<FourCrossPaint_IronBoxAI> ().MissionComplete ();
			missionCompleteDialog.GetComponent<FourCrossPaint_MissionCompleteDialog> ().MissionComplete ();

		}

	}
}
