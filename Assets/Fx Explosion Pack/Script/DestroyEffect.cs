using UnityEngine;
using System.Collections;

public class DestroyEffect : MonoBehaviour {

	void Start(){
		Invoke("EndObj",3f);
	}

	void Update ()
	{
		return;
		if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.C))
		   Destroy(transform.gameObject);
	
	}

	void EndObj(){
		Destroy(transform.gameObject);
	}
}
