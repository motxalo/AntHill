using UnityEngine;
using System.Collections;

public class CharExcavadora : MonoBehaviour {

	private PlayerController controller;

	public float timeToRestore = 5f;

	// Use this for initialization
	void Start () {
		controller = GetComponent<PlayerController>();
	}

	// Update is called once per frame
	void Update () {

	}

	public void DoSpecialAttack(){
		CheckTeleportDestiny();
	}

	void CheckTeleportDestiny(){
		Vector3 nearest = transform.position + 3f*transform.forward;
		if(MapManager.GetTile(Mathf.FloorToInt(nearest.x),Mathf.FloorToInt(nearest.z)) == 0){
			Vector3 tpos = new Vector3(Mathf.FloorToInt(nearest.x), transform.position.y , Mathf.FloorToInt(nearest.z));
			Teleport(tpos);
		}
	}

	void Teleport(Vector3 pos){
		transform.position = pos;
		controller.canSpecial = false;
		Invoke("RestoreSpecialAttack",timeToRestore);
	}

	public void RestoreSpecialAttack(){
		controller.canSpecial = true;
	}	
}
