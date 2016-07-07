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

	private Vector3 startPos;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
		gameObject.name="Player"+playerId;
		realBombfrec = 0f;
		canMove = true;
		rb = GetComponent<Rigidbody>();
		SetupCamera();
		SetupTeam();
	}
	
	// Update is called once per frame
	void Update () {
		if (!canMove || Time.timeScale == 0f) return;
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
			Destroy(panelDebug);
			//panelDebug.transform.position = new Vector3(Mathf.FloorToInt(transform.position.x) + .5f, .1f, Mathf.FloorToInt(transform.position.z) + .5f);
		}
	}

	public GameObject panelDebug;

	void Bomba(){
		Vector3 nearest = transform.position;// + transform.forward;
		Vector3 tpos = new Vector3(Mathf.FloorToInt(nearest.x), 0, Mathf.FloorToInt(nearest.z));
		Instantiate(bomba, tpos + new Vector3(.5f,0f,.5f), Quaternion.identity);
		realBombfrec = 0f;
	}

	void Die(){
		if(!canMove) return;
		Debug.Log(" DIE : "+gameObject.name);
		canMove = false;
		rb.isKinematic = true;
		oldColor = GetComponent<Renderer>().material.color;
		GetComponent<Renderer>().material.color = Color.black;
		GameObject.Find("GameMode").SendMessage("Death",this,SendMessageOptions.DontRequireReceiver);
	}

	private Color oldColor;

	public void Respawn(float _time){
		Invoke("RealRespawn",_time);
	}

	void RealRespawn(){
		canMove = true;
		rb.isKinematic = false;
		GetComponent<Renderer>().material.color = oldColor;
		transform.position = startPos;
		canMove = true;
	}

	// TEEAM FUNCTIONS 

	public int teamId;

	void SetupTeam(){
		// Solo miro el numero de jugadores, pero habria q mirar tb el modo de juego,
		if (PlayerPrefs.GetInt("Players")>= 3 && playerId >= 2 || PlayerPrefs.GetInt("Players") == 2 && playerId == 1)
			teamId = 1;
		else 
			teamId=0;
	}

	public int GetTeam(){
		return teamId;
	}

	// CAMERA FUNCTIONS


	void SetupCamera(){
		GetComponentInChildren<PlayerCamera>().SetPlayerMode(PlayerPrefs.GetInt("Players"),playerId);
	}

	// TRIGGER FUNCTIONS

	void OnTriggerEnter(Collider other){
		if(other.tag == "object")
			other.gameObject.SendMessage("PlayerEnter", this,  SendMessageOptions.DontRequireReceiver);
	}

	void OnTriggerExit(Collider other) {
		other.gameObject.SendMessage("PlayerExit",this, SendMessageOptions.DontRequireReceiver);
	}

	// FLAG FUNCTIONS

	private Flag flag;

	public void GetFlag(Flag _flag){
		if(flag == null )
		flag = _flag;
	}

	public void ScoreFlag(){
		if(flag!=null){
			Debug.Log (" POINT SCORED TEAM : "+teamId);
			GameObject.Find("GameMode").GetComponent<CaptureTheFlag>().PointScored(teamId);
			RemoveFlag();
		}
	}

	public void RemoveFlag(){
		if (flag != null){
			flag.Restore();
			flag = null;
		}
	}
}
