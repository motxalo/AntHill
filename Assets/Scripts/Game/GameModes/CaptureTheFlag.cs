using UnityEngine;
using System.Collections;

public class CaptureTheFlag : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt("GameMode") != 2)
			Destroy(this);
		points = new int[2];
		points[0]=0;
		points[1]=0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Death(PlayerController player){
		player.Respawn(1f);
	}

	public int[] points;
	public void PointScored(int teamId){
		points[teamId] += 1;
	}
}
