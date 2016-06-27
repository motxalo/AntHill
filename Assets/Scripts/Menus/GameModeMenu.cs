using UnityEngine;
using System.Collections;

public class GameModeMenu : MonoBehaviour {

	public void Start1PGame(){
		PlayerPrefs.SetInt("Players",1);
		Application.LoadLevel(1);
	}

	public void Start2PGame(){
		PlayerPrefs.SetInt("Players",2);
		Application.LoadLevel(1);
	}
}
