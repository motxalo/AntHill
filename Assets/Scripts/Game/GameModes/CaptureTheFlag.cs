using UnityEngine;
using System.Collections;

public class CaptureTheFlag : MonoBehaviour {

	public UnityEngine.UI.Text[] scorers;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt("GameMode") != 2){
			Destroy(scorers[0].transform.parent.gameObject);
			Destroy(this);
		}
		points = new int[2];
		points[0]=0;
		points[1]=0;
		scorers[0].text = ""+points[0];
		scorers[1].text = ""+points[1];
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
		scorers[teamId].text = ""+points[teamId];
	}
}
