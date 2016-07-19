using UnityEngine;
using System.Collections;

public class MapSegment : MonoBehaviour {
	// DEPRECATED
	/*
	public Vector2 id;
	public MapSegment[] linkedSegments;
	public bool autoSetSegments = true;
	// Usethis for initialization
	void Start () {
		string[] tName = gameObject.name.Split('_');
		id.x = int.Parse(tName[1]);
		id.y = int.Parse(tName[2]);
		transform.position = new Vector3(id.x * 100f, -.5f, id.y * 100f);
		if(autoSetSegments){
			
		}
	}

	public void RemoveUnlinked( Vector2[] newPool ){
		for (int i = 0; i < linkedSegments.Length; i++){
			bool destroy = true;
			for (int k = 0; k< newPool.Length; k++){
				if ( linkedSegments[i] == newPool[k] )
					destroy = false;
			}
			if(destroy)
				linkedSegments[i].gameObject.SetActive(false);
		}
	}

	void OnTriggerEnter(Collider other){
		Vector2 tempPool = new Vector2[linkedSegments.Length];
		for (int i=0; i < linkedSegments.Length; i++){
			tempPool[i] = linkedSegments[i].id;	
		}
		SegmentManager.SetActualSegment(this, tempPool);
		
	}

	// Update is called once per frame
	void Update () {
	
	}
	*/
}
