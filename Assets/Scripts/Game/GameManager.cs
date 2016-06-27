﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject[] players;
	public GameObject[] canvases;

	// Use this for initialization
	void Start () {
		StartGame();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void StartGame(){
		// CARGAR MAPA
		GameObject.Find("Map").GetComponent<LoadLevel>().DoLoading();
		// CARGAR PLAYER
		int playersAmount = PlayerPrefs.GetInt("Players");
		Debug.Log("INIT GAME "+playersAmount+" PLAYERS");
		for (int i = 0; i<playersAmount; i++){
			GameObject player = GameObject.Instantiate(players[i] as GameObject) ;
			Vector2 pos = MapManager.GetPlayerPos(i);
			player.transform.position = new Vector3(pos.x, 0f, pos.y) + new Vector3(.5f,.5f,.5f);;
		}
		// CONFIGURAR TIPO JUEGO
		for (int i = 0; i<canvases.Length; i++){
			if( (i+1) != playersAmount )
				canvases[i].SetActive(false);
		}
	}
}
