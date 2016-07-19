using UnityEngine;
using System.Collections;

public class DoorTranslator : MonoBehaviour {
	public Vector2 destLevel = Vector2.zero;
	public int	 destSpawn = 0;
	Transform destiny;
	private int players;
	// Use this for initialization
	void Start	 () {
		players = PlayerPrefs.GetInt("Players");
	}

	void Update(){
		
	}

	public void PlayerEnter(PlayerController _player){
		players--;
		_player.ForceMove(destiny.position);
		PlayerPrefs.SetString("MAPNAME","Story_"+destLevel.x+"_"+destLevel.y);
		PlayerPrefs.SetInt ("SPAWN",destSpawn);
		//Destroy(gameObject);
	}

}
