using UnityEngine;
using System.Collections;

public class SymmetryPuzzle : MonoBehaviour {

	public GameObject clock;
	public GameObject brokenClock;
	public GameObject backGround;

	public GameObject goBackPaint;
	public GameObject fastFowardPaint;
	public GameObject umBrellaGirlPaint_Left;
	public GameObject umBrellaGirlPaint_Right;
	public GameObject missionCompleteDialog;

	public GameObject teleportPoint_Left;
	public GameObject teleportPoint_Right;
	public GameObject newCollider_Left;
	public GameObject newCollider_Right;

	public Sprite umbrellaGirlWithBlood_Left;
	public Sprite umbrellaGirlWithBlood_Right;
	public Sprite newBackGroundImage;

	private static bool isSymmetryPuzzleOver;

	// Use this for initialization
	void Start () {
		if (isSymmetryPuzzleOver) {
			goBackPaint.SetActive (false);
			fastFowardPaint.GetComponent<FastFowardPaintAI> ().MissionComplete ();
			umBrellaGirlPaint_Left.SetActive (false);
			umBrellaGirlPaint_Right.transform.FindChild ("GirlWithNoUmbrella").GetComponent<SpriteRenderer> ().sprite = umbrellaGirlWithBlood_Right;
			FindObjectOfType<CameraController> ().gameObject.transform.position = new Vector3 (9.3f, -1.1f, 0);
			FindObjectOfType<CameraController> ().cameraMinX = 10;
			backGround.GetComponent<SpriteRenderer> ().sprite = newBackGroundImage;
			backGround.transform.position = new Vector3 (20.2f, -1.3f, 0);
			teleportPoint_Left.SetActive (false);
			teleportPoint_Right.SetActive (false);
			newCollider_Left.SetActive (true);
			newCollider_Right.SetActive (true);
			brokenClock.SetActive (true);
			clock.SetActive (false);
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
		}
	}

}
