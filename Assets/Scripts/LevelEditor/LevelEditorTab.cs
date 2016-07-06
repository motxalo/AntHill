﻿using UnityEngine;
using System.Collections;

public class LevelEditorTab : MonoBehaviour {

    public bool hide = false;
    public Vector3 target;
    public float speed = 0.5f;
    public GameObject menu;
    public GameObject other;

    // Use this for initialization
    void Start () {
        if (hide)
        {
            target = new Vector3(25, 0, -5);
        }
        else
        {
            target = new Vector3(0, 0, -5);
        }
    }
	
	// Update is called once per frame
	void Update () {
        menu.transform.position = Vector3.Lerp(menu.transform.position, target, speed);
    }

    public void DoClicked()
    {
        if (hide)
        {
            hide = false;
            target = new Vector3(5, 0, -5);
            other.transform.GetComponent<LevelEditorTab>().hide = true;
            other.transform.GetComponent<LevelEditorTab>().target = new Vector3(25, 0, -5);
        }
        else
        {
            hide = true;
            target = new Vector3(25, 0, -5);
        }
            
    }
}
