using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

	public enum CameraMode{
		perspective,
		orthographic
	}

	public CameraMode cameraMode = CameraMode.perspective;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// DEBUG
		if (Input.GetKeyDown(KeyCode.V))
			ChangeCameraMode(CameraMode.orthographic);
		if (Input.GetKeyDown(KeyCode.B))
			ChangeCameraMode(CameraMode.perspective);
	}

	public void ChangeCameraMode(CameraMode newCamMode){
		cameraMode = newCamMode;
		switch (newCamMode){
		case CameraMode.orthographic:
			GetComponent<Camera>().orthographic = true;
			transform.localPosition = new Vector3(0f,9f,.0f);
			transform.rotation = Quaternion.Euler(new Vector3(90f,0f,0f));
			break;
		case CameraMode.perspective:
			GetComponent<Camera>().orthographic = false;
			transform.localPosition = new Vector3(0f,9f,-7.7f);
			transform.LookAt (transform.parent);
			break;
		}
	}

	public void SetPlayerMode(int playerAmount, int playerId){
		Camera cam = GetComponent<Camera>();
		if (playerAmount == 1){
			cam.rect = new Rect(0f,0f,1f,1f);
			return;
		}
		if (playerAmount == 2){
			if (playerId == 0){
				cam.rect = new Rect(0f,0f,.5f,1f);
			}
			if (playerId == 1){
				cam.rect = new Rect(0f,0.5f,.5f,1f);
			}
			return;
		}
	}
}
