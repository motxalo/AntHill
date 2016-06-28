using UnityEngine;
using System.Collections;

public class LevelEditorGenerator : MonoBehaviour {

	public GameObject editorEmptyTile;

	public Vector2 canvasSize = new Vector2(50,50);

	// Use this for initialization
	void Start () {
		CreateEditorPlane();
		Camera.main.GetComponent<LevelEditorCamera>().SetupBounds (canvasSize);
		LevelEditorManager.Init(Mathf.FloorToInt(canvasSize.x),Mathf.FloorToInt(canvasSize.y));
	}

	void CreateEditorPlane () {
		for(int i=0; i<canvasSize.x; i++)
			for(int k=0; k<canvasSize.y; k++){
				GameObject tgo =	Instantiate(editorEmptyTile,new Vector3(i*10,k*10, 0), editorEmptyTile.transform.rotation) as GameObject;
				tgo.transform.parent = transform;
				tgo.name = "tile_"+i+"_"+k;
			}
	}
}
