using UnityEngine;
using System.Collections;

public class InGameMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		HideMenu();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P))
			ShowMenu();
	}

	public void ShowMenu(){
		GetComponent<Canvas>().enabled = true;
		Time.timeScale = 0f;
	}

	public void HideMenu(){
		GetComponent<Canvas>().enabled = false;
		Time.timeScale = 1f;
	}

	public void ExitToMenu(){
		Application.LoadLevel(0);
	}
}
