using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject[] players;
	public GameObject[] canvases;
	public GameObject cameraFixed; // Esta camara solo se mantendrá activa en caso de q el juego sea a 3 jugadore sy quede un cuadro libre
	// Use this for initialization
	void Start () {
		StartGame();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
	}

	void StartGame(){
		// CARGAR MAPA
		GameObject.Find("Map").GetComponent<LoadLevel>().DoLoading();
		// CARGAR PLAYER
		int playersAmount = PlayerPrefs.GetInt("Players");
		cameraFixed.SetActive(playersAmount==3);
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

	}
}
