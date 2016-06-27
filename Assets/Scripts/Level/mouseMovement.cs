using UnityEngine;
using System.Collections;

public class mouseMovement : MonoBehaviour {
	Vector3 posMouse;
	public Material newMaterial;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray touchRay = new Ray (transform.position, Vector3.forward);
		int rayDistance = 40;
		Debug.DrawRay (transform.position, Vector3.forward * rayDistance);
		if(Physics.Raycast(touchRay,out hit, rayDistance)){
			if (hit.transform.tag == "planosEditor") {
				hit.transform.GetComponent<MeshRenderer> ().material = newMaterial;
			}
		}
		posMouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.position = new Vector3(posMouse.x,posMouse.y,0);
	}
}
