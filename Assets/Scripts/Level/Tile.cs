using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	public void Die(){
		Debug.Log(" BROKEN : "+name);
		MapManager.SetTile(Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.z), 0);
		Invoke("RealDie",.05f);
	}

	void RealDie(){
		Destroy(gameObject);
	}
}
