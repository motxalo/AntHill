using UnityEngine;
using System.Collections;

public class LevelEditorButton : MonoBehaviour {

	private mouseMovement editorController;

	public int tileId;
	public bool save=false;
	// Use this for initialization
	void Start () {
		editorController = GameObject.Find("Sphere").GetComponent<mouseMovement>();
	}
	

	public void DoClicked () {
		if (save) {
			LevelEditorManager.SaveToXML ();
		}
		else
			editorController.SetSelectedTile(tileId,GetComponent<MeshRenderer>().material.mainTexture);
	}
}
