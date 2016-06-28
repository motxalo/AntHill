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
		if(selectedTileId < 0) return;
		RaycastHit hit;
		Ray touchRay = new Ray (transform.position, Vector3.forward);
		int rayDistance = 20;
		Debug.DrawRay (transform.position, Vector3.forward * rayDistance);
		if (Input.GetMouseButton(0)) {
			if (Physics.Raycast (touchRay, out hit, rayDistance)) {
				if (hit.transform.tag == "planosEditor") {
					//hit.transform.GetComponent<MeshRenderer> ().material = newMaterial;
					hit.transform.GetComponent<MeshRenderer> ().material.SetTexture("_MainTex", selectedTileTexture);
				}
			}
		}
		posMouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.position = new Vector3(posMouse.x,posMouse.y,transform.position.z);
	}

	private Texture selectedTileTexture;
	private int 	   selectedTileId = -1;

	public void SetSelectedTile(int _id, Texture _tex){
		selectedTileId = _id;
		selectedTileTexture = _tex;
	}

	/*
	public Texture btnDirtTexture;
	public Texture btnRockTexture;
	public Texture btnDotsTexture;

	void OnGUI() {		
		if (GUI.Button (new Rect (Screen.width - 110, 10, 100, 100), btnDirtTexture))
			newTexture = btnDirtTexture;
		if (GUI.Button (new Rect (Screen.width - 110, 120, 100, 100), btnRockTexture))
			newTexture = btnRockTexture;
		if (GUI.Button (new Rect (Screen.width - 110, 230, 100, 100),btnDotsTexture))
			newTexture = btnDotsTexture;
	}
	*/

}
