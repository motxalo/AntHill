using UnityEngine;
using System.Collections;

public class LevelEditorButton : MonoBehaviour {

	private mouseMovement editorController;
	public int tileId;
	// Use this for initialization
	void Start () {
		editorController = GameObject.Find("Sphere").GetComponent<mouseMovement>();
	}
	

	public void DoClicked () {
		editorController.SetSelectedTile(tileId,GetComponent<MeshRenderer>().material.mainTexture);
	}
}
