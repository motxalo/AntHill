﻿using UnityEngine;
using System.Collections;

public class mouseMovement : MonoBehaviour {
	Vector3 posMouse;
	public Material newMaterial;
	public bool pathMode;
	public Texture pathTexture;
	public Texture2D normalCursor;
	public Texture2D blockedCursor;
	public int enemyX;
	public int enemyY;

	// Use this for initialization
	void Start () {
		Cursor.SetCursor(normalCursor,new Vector2(0,0),CursorMode.ForceSoftware);
	}

    // Update is called once per frame
    void Update() {
        RaycastHit hit;
        Ray touchRay = new Ray(transform.position, Vector3.forward);
        int rayDistance = 20;
        Debug.DrawRay(transform.position, Vector3.forward * rayDistance);

		if (pathMode) {
			if (Physics.Raycast (touchRay, out hit, rayDistance)) {
				if (hit.transform.tag == "planosEditor") {
					string[] cellname = hit.transform.name.Split ('_');
					LevelEditorManager.SetTile (int.Parse (cellname [1]), int.Parse (cellname [2]), selectedTileId);
					if (int.Parse (cellname [1]) == enemyX || int.Parse (cellname [2]) == enemyY) {
						Cursor.SetCursor(normalCursor,new Vector2(0,0),CursorMode.ForceSoftware);
						if (Input.GetMouseButtonDown (0)) {
                            hit.transform.GetComponent<Renderer>().material.color = Color.green;
                            //aqui habria que guardar el tile, y tintarlo o algo para que se vea
                            enemyX = int.Parse (cellname [1]);
							enemyY = int.Parse (cellname [2]);
						}
					}
					else
						Cursor.SetCursor(blockedCursor,new Vector2(0,0),CursorMode.ForceSoftware);
				}
			}
		} else {

			if (Input.GetKey (KeyCode.LeftShift)) {
				if (Input.GetMouseButton (0)) {
					if (Physics.Raycast (touchRay, out hit, rayDistance)) {
						if (hit.transform.tag == "planosEditor") {
							if (selectedTileId < 0)
								return;
							hit.transform.GetComponent<MeshRenderer> ().material.SetTexture ("_MainTex", selectedTileTexture);
							// RELLENO LA LISTA DE TILES
							string[] cellname = hit.transform.name.Split ('_');
							LevelEditorManager.SetTile (int.Parse (cellname [1]), int.Parse (cellname [2]), selectedTileId);
						}
					}
				}
			} else {
				if (Input.GetMouseButtonDown (0)) {
					if (Physics.Raycast (touchRay, out hit, rayDistance)) {
						if (hit.transform.tag == "planosEditor") {
							if (selectedTileId < 0)
								return;
							hit.transform.GetComponent<MeshRenderer> ().material.SetTexture ("_MainTex", selectedTileTexture);
							// RELLENO LA LISTA DE TILES
							string[] cellname = hit.transform.name.Split ('_');
							LevelEditorManager.SetTile (int.Parse (cellname [1]), int.Parse (cellname [2]), selectedTileId);
							Debug.Log (selectedTileId);
							if (selectedTileId > 300) {
								pathMode = true;
								enemyX = int.Parse(cellname [1]);
								enemyY = int.Parse(cellname [2]);
							}
						} else if (hit.transform.tag == "botonEditor") {
							hit.transform.GetComponent<LevelEditorButton> ().DoClicked ();
						} else if (hit.transform.tag == "tabEditor") {
							hit.transform.GetComponent<LevelEditorTab> ().DoClicked ();
						}
					}
				}
			}
		}
		posMouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.position = new Vector3(posMouse.x,posMouse.y,transform.position.z);
	}

	private Texture 	selectedTileTexture;
	private int 	   	selectedTileId = -1;
	public  Renderer    debugTile;

	public void SetSelectedTile(int _id, Texture _tex){
		selectedTileId = _id;
		selectedTileTexture = _tex;
		debugTile.material.SetTexture("_MainTex",selectedTileTexture);
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
