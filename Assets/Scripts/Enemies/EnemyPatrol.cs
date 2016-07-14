using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {

	public enum PathType{
		loop, 
		pingPong,
	}

	public PathType pathType = PathType.loop;

	public Vector2[] path;

	public float speed = 1f;

	public bool alive = true;
	private int actPos = 0;
	private float distanceLimit = .1f;
	// Use this for initialization
	void Start () {
		Initialise();
	}

	void Initialise(){
		transform.position = new Vector3(path[0].x, .5f, path[0].y);
		actPos = 1;
		alive = true;
	}

	// Update is called once per frame
	void Update () {
		if (alive)
			UpdateWalk();
	}

	void UpdateWalk(){
		Vector3 destPos = new Vector3(path[actPos].x, .5f, path[actPos].y);
		transform.LookAt (destPos);
		transform.position = Vector3.MoveTowards(transform.position, destPos, speed * Time.deltaTime );
		//transform.position = Vector3.Lerp(transform.position, destPos, speed * Time.deltaTime );
		if ( Vector3.Distance(transform.position, destPos ) <= distanceLimit )
		{
			actPos = (actPos+1) % path.Length; 
			if(pathType == PathType.pingPong && actPos == 0){
				ReorderDestVector();
			}
		}
	}

	void ReorderDestVector(){
		Vector2[] tVector = new Vector2[path.Length];
		for (int i = 0; i<path.Length; i++){
			tVector[i] = path[path.Length - (i+1)];
		}
		path = tVector;
	}
		
	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			other.transform.parent.SendMessage("Die",-1);
		}
		else
			Destroy ( gameObject );
	}
}
