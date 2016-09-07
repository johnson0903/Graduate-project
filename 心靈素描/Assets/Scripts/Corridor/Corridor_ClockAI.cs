using UnityEngine;
using System.Collections;

public class Corridor_ClockAI : MonoBehaviour {

	private static int hour;

	// Use this for initialization
	void Start () {
		hour = 8;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.FindChild ("Hour").transform.rotation = Quaternion.Euler(0, 0, hour * (-30));
	}

	public void AdjusyTime(int range){
		hour += range;
		if (hour >= 12)
			hour -= 12;
		else if (hour < 0)
			hour += 12;
	}

	public int Hour {
		get{ return hour; }
	}
}
