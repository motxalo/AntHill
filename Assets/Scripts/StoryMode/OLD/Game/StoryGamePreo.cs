using UnityEngine;
using System.Collections;

public class StoryGamePreo : MonoBehaviour {
	//DEPRECATED
	/*
	public GameObject[] players;
	public GameObject[] canvases;
	// Use this for initialization
	void Awake () {
		PlayerPrefs.SetInt("Players",1);
		PlayerPrefs.SetInt("Character0",1);
	
	}

	void Start(){
		MapManager.Init (100,100);
		StartGame();
	}


	// Update is called once per frame
	void Update () {
	
	}

	void StartGame(){
		// CARGAR MAPA
		MapManager.InitPlayers(1);
//		GameObject.Find("Map").GetComponent<LoadLevel>().DoLoading();
		// CARGAR PLAYER
		int playersAmount = PlayerPrefs.GetInt("Players");
		StatManager.InitStats(playersAmount);
		Debug.Log("INIT GAME "+playersAmount+" PLAYERS");
		for (int i = 0; i<playersAmount; i++){
			GameObject player = GameObject.Instantiate(players[PlayerPrefs.GetInt("Character"+i)] as GameObject) ;
			player.GetComponent<PlayerController>().InitWithId(i);
			Vector2 pos = MapManager.GetPlayerPos(i);
			player.transform.position = new Vector3(pos.x, 0f, pos.y) + new Vector3(.5f,.5f,.5f);;
		}
		// CONFIGURAR TIPO JUEGO
		for (int i = 0; i<canvases.Length; i++){
			if( (i+1) != playersAmount )
				canvases[i].SetActive(false);
		}
	}*/
}
