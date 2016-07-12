using UnityEngine;
using System.Collections;

public class CharDefensa : MonoBehaviour {

	private PlayerController controller;

	public float timeToRestore = 5f;
	public float shieldTime = 2f;
	// Use this for initialization
	void Start () {
		controller = GetComponent<PlayerController>();
	}

	// Update is called once per frame
	void Update () {

	}

	public void DoSpecialAttack(){
		controller.canSpecial = false;
		Invoke("RestoreSpecialAttack",timeToRestore);
		Invoke("RestoreShield",shieldTime);
		controller.SetShield(true);
	}

	void RestoreShield(){
		controller.SetShield(false);
	}

	public void RestoreSpecialAttack(){
		controller.canSpecial = true;
	}	
}
