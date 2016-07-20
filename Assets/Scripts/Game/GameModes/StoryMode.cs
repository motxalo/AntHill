using UnityEngine;
using System.Collections;

public class StoryMode : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Death(PlayerController player){
		player.Respawn(1f);
	}
}
