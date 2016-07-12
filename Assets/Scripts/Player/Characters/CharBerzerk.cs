using UnityEngine;
using System.Collections;

public class CharBerzerk : MonoBehaviour {

	private PlayerController controller;

	public float timeToRestore = 5f;

	// Use this for initialization
	void Start () {
		controller = GetComponent<PlayerController>();
	}

	// Update is called once per frame
	void Update () {

	}

	float hitDistance = 1f;

	public void DoSpecialAttack(){
		controller.canSpecial = false;
		Invoke("RestoreSpecialAttack",timeToRestore);
		CuerpoACuerpoMuerte();
	}

	public void RestoreSpecialAttack(){
		controller.canSpecial = true;
	}	

	void CuerpoACuerpoMuerte(){
		RaycastHit hit;
		if (Physics.Raycast(transform.position + new Vector3(0f,.1f,0f) + transform.forward*.4f, transform.forward,out hit, hitDistance)){
			if(hit.collider.tag == "Player"){
				hit.collider.SendMessage("Die");
			}
			Debug.Log("ATAQUE BERSERKER A : "+hit.collider.name);
		}
	}
}
