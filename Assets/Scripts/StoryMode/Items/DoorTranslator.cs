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
		destiny = transform.GetChild(0).transform;
	}

	void Update(){
		
	}

	public void PlayerEnter(PlayerController _player){
		players--;
		if (players == 0){
			StartCoroutine(NextLevel());
		}
		_player.ForceMove(destiny.position);
		//Destroy(gameObject);
	}

	IEnumerator NextLevel(){
		GameObject.Find("CanvasFader").GetComponent<Fader>().FadeOut(1f);
		yield return new WaitForSeconds(1f);
		PlayerPrefs.SetString("MAPNAME","Story_"+destLevel.x+"_"+destLevel.y);
		PlayerPrefs.SetInt ("SPAWN",destSpawn);
		Application.LoadLevel(Application.loadedLevel);
	}

}
