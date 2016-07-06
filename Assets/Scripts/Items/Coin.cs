using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {
	public float rotateSpeed = 5f;


	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.forward, Time.deltaTime * rotateSpeed);
	}

	public void PlayerEnter(PlayerController _player){
		Destroy(gameObject);
	}
}
