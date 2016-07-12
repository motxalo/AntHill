using UnityEngine;
using System.Collections;

public class CharObrera : MonoBehaviour {

	private PlayerController controller;

	// Use this for initialization
	void Start () {
		controller = GetComponent<PlayerController>();
	}

	// Update is called once per frame
	void Update () {

	}

	public void DoSpecialAttack(){
		controller.canSpecial = false;
	}
}
