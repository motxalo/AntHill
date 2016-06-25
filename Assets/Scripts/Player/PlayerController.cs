using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int playerId = 0;
	public Vector2 speed = new Vector2(1f,1f);
	public 	float bombFrec = 1f;
	private float realBombfrec = 0f;
	private Rigidbody rb;

	public GameObject bomba;

	private bool canMove =true;

	// Use this for initialization
	void Start () {
		realBombfrec = 0f;
		canMove = true;
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!canMove) return;
		realBombfrec += Time.deltaTime;
		Vector3 movement = Vector3.zero;
		movement += transform.forward 	* Input.GetAxis("Vertical"+playerId) 	* speed.x;
		transform.RotateAround(transform.position, Vector3.up, Input.GetAxis("Horizontal"+playerId)	* speed.y);
		//movement += transform.right 	* Input.GetAxis("Horizontal"+playerId)	* speed.y;
		if(movement!= Vector3.zero){
		//	Debug.Log("MOVEMENT : "+movement);
			rb.velocity = movement;
			//rb.MovePosition(transform.position + movement*Time.deltaTime);
		}

		if (realBombfrec >= bombFrec && Input.GetButtonDown("Bomb"+playerId)){
			Bomba();	
		}

		MapManager.PlayerIn(Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.z), playerId);
		if(panelDebug){
			panelDebug.transform.position = new Vector3(Mathf.FloorToInt(transform.position.x) + .5f, .1f, Mathf.FloorToInt(transform.position.z) + .5f);
		}
	}

	public GameObject panelDebug;

	void Bomba(){
		Vector3 nearest = transform.position;// + transform.forward;
		Vector3 tpos = new Vector3(Mathf.FloorToInt(nearest.x), 0, Mathf.FloorToInt(nearest.z));
		//if(MapManager.GetTile(Mathf.RoundToInt(nearest.x), Mathf.RoundToInt(nearest.z)) == 0){
			Instantiate(bomba, tpos + new Vector3(.5f,0f,.5f), Quaternion.identity);
			realBombfrec = 0f;
		//}
	}

	void Die(){
		Debug.Log(" DIE : "+gameObject.name);
		canMove = false;
		GetComponent<Renderer>().material.color = Color.black;
	}
}
