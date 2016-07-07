using UnityEngine;
using System.Collections;

public class Flag : MonoBehaviour {

	public int flagId = 0;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt("GameMode") != 2){
			Destroy(this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetID(int _id){
		flagId = _id - 201;
	}

	public void PlayerEnter(PlayerController _player){
		if (_player.GetTeam() != flagId ){
			gameObject.SetActive(false);
			_player.GetFlag(this);
		}else 
			_player.ScoreFlag();
	}

	public void Restore(){
		gameObject.SetActive(true);
	}
}
