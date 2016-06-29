﻿using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

	public enum CameraMode{
		perspective,
		orthographic,
		firstPreson,
	}

	public CameraMode cameraMode = CameraMode.perspective;

	// Use this for initialization
	void Start () {
		ChangeCameraMode(CameraMode.perspective);
	}
	
	// Update is called once per frame
	void Update () {
		// DEBUG
		if (Input.GetKeyDown(KeyCode.Alpha1))
			ChangeCameraMode(CameraMode.orthographic);
		if (Input.GetKeyDown(KeyCode.Alpha2))
			ChangeCameraMode(CameraMode.perspective);
		if (Input.GetKeyDown(KeyCode.Alpha3))
			ChangeCameraMode(CameraMode.firstPreson);
	}

	public void ChangeCameraMode(CameraMode newCamMode){
		cameraMode = newCamMode;
		switch (newCamMode){
		case CameraMode.orthographic:
			GetComponent<Camera>().orthographic = true;
			GetComponent<Camera>().nearClipPlane = .3f;
			transform.localPosition = new Vector3(0f,9f,.0f);
			transform.localRotation = Quaternion.Euler(new Vector3(90f,0f,0f));
			break;
		case CameraMode.perspective:
			GetComponent<Camera>().orthographic = false;
			GetComponent<Camera>().nearClipPlane = .3f;
			transform.localPosition = new Vector3(0f,9f,-7.7f);
			transform.localRotation = Quaternion.Euler(new Vector3(65f,0f,0f));
			break;
		case CameraMode.firstPreson:
			GetComponent<Camera>().orthographic = false;
			GetComponent<Camera>().nearClipPlane = 0.1f;
			transform.localPosition = Vector3.zero;
			transform.localRotation = Quaternion.Euler(Vector3.zero);
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
				cam.rect = new Rect(0.5f,0f,.5f,1f);
			}
			return;
		}
		if (playerAmount == 3){
			if (playerId == 0){
				cam.rect = new Rect(0f,0.5f,.5f,.5f);
			}
			if (playerId == 1){
				cam.rect = new Rect(0.5f,0.5f,.5f,.5f);
			}
			if (playerId == 2){
				cam.rect = new Rect(0f,0f,.5f,.5f);
			}
			return;
		}
		if (playerAmount == 4){
			if (playerId == 0){
				cam.rect = new Rect(0f,0.5f,.5f,.5f);
			}
			if (playerId == 1){
				cam.rect = new Rect(0.5f,0.5f,.5f,.5f);
			}
			if (playerId == 2){
				cam.rect = new Rect(0f,0f,.5f,.5f);
			}
			if (playerId == 3){
				cam.rect = new Rect(0.5f,0f,.5f,.5f);
			}
			return;
		}

	}
}
