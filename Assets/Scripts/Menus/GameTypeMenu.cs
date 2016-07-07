using UnityEngine;
using System.Collections;

public class GameTypeMenu : MonoBehaviour {


	public void StartFreeWalkMode () {
		PlayerPrefs.SetInt("GameMode",0);
		Application.LoadLevel(2);
	}


	public void StartFlagMode () {
		PlayerPrefs.SetInt("GameMode",2);
		Application.LoadLevel(2);
	}	

	public void StartDeathmatch () {
		PlayerPrefs.SetInt("GameMode",1);
		Application.LoadLevel(2);
	}

	public void BackToMenu(){
		Application.LoadLevel(0);
	}
}
