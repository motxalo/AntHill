using UnityEngine;
using System.Collections;

public class Deathmatch : MonoBehaviour {

	public UnityEngine.UI.Text[] scorers;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt("GameMode") != 1){
			Destroy(scorers[0].transform.parent.gameObject);
			Destroy(this);
		}
		points = new int[4];
		points[0]=0;
		points[1]=0;
		points[2]=0;
		points[3]=0;
		int players = PlayerPrefs.GetInt("Players");
		for (int i = players; i < 4; i++)
			Destroy(scorers[i].gameObject);
	}
	
	public void Death(PlayerController player){
		player.Respawn(5f);
		PointScored(player.playerId);
		Debug.Log("KILLSTREAM : "+player.playerId);
	}

	public int[] points;
	public void PointScored(int teamId){
		points[teamId] += 1;
		scorers[teamId].text = ""+points[teamId];
	}
}
