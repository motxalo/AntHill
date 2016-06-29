using UnityEngine;
using System.Collections;

public class LevelEditorCamera : MonoBehaviour {

	public Vector4 bounds =  new Vector4(60f,440f,30f,460f);
	private Vector2 boundModifier = new Vector2(7.5f, 8.5f);
	private Vector3 tpos;
	public float speed = 10f;
	// Use this for initialization
	void Start () {
		isStatic = false;
		tpos = transform.position;
		tpos.x = bounds.x;
		tpos.y = bounds.z;
		botonera = transform.GetChild(0).gameObject;
	}

	public void SetupBounds(Vector2 cells){
		bounds.y = bounds.x + boundModifier.x * cells.x + boundModifier.x;
		bounds.w = bounds.z + boundModifier.y * cells.y + boundModifier.y;
	}

	public bool isStatic = false;
	private GameObject botonera;
	// Update is called once per frame
	void Update () {
		if(!isStatic){
			tpos.x = Mathf.Clamp(tpos.x + Input.GetAxis("Horizontal0")*speed, bounds.x, bounds.y);
			tpos.y = Mathf.Clamp(tpos.y + Input.GetAxis("Vertical0")*speed, bounds.z, bounds.w);
			transform.position = tpos;
			if(Input.GetKeyDown(KeyCode.Space))
				ChangeMode(true);
		}else{
			if(Input.GetKeyDown(KeyCode.Space))
				ChangeMode(false);
		}
	}

	public Vector3 oldPos;

	void ChangeMode(bool _newMode){
		isStatic = _newMode;
		if(isStatic){
			oldPos = transform.position;
			tpos.x = bounds.x + (bounds.y - bounds.x)/2f;
			tpos.y = bounds.z + (bounds.w - bounds.z)/2f;
			transform.position = tpos;
			GetComponent<Camera>().orthographicSize = 280f;
			botonera.SetActive(false);
		}else{
			botonera.SetActive(true);
			tpos = oldPos;
			GetComponent<Camera>().orthographicSize = 45;
		}
	}
}
