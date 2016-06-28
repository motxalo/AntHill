using UnityEngine;
using System.Collections;

public class LevelEditorCamera : MonoBehaviour {

	public Vector4 bounds =  new Vector4(60f,440f,30f,460f);
	private Vector2 boundModifier = new Vector2(7.5f, 8.5f);
	private Vector3 tpos;
	public float speed = 10f;
	// Use this for initialization
	void Start () {
		tpos = transform.position;
		tpos.x = bounds.x;
		tpos.y = bounds.z;
	}

	public void SetupBounds(Vector2 cells){
		bounds.y = bounds.x + boundModifier.x * cells.x + boundModifier.x;
		bounds.w = bounds.z + boundModifier.y * cells.y + boundModifier.y;
	}

	// Update is called once per frame
	void Update () {
		tpos.x = Mathf.Clamp(tpos.x + Input.GetAxis("Horizontal0")*speed, bounds.x, bounds.y);
		tpos.y = Mathf.Clamp(tpos.y + Input.GetAxis("Vertical0")*speed, bounds.z, bounds.w);
		transform.position = tpos;
	}
}
