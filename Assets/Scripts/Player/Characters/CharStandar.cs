using UnityEngine;
using System.Collections;

public class CharStandar : MonoBehaviour {

	private PlayerController controller;
	public GameObject mina;
	public float timeToRestore = 5f;

	// Use this for initialization
	void Start () {
		controller = GetComponent<PlayerController>();
	}

	// Update is called once per frame
	void Update () {

	}

	public void DoSpecialAttack(){
		controller.canSpecial = false;
		Bomba();
		Invoke("RestoreSpecialAttack",timeToRestore);
	}	

	public void RestoreSpecialAttack(){
		controller.canSpecial = true;
	}	

	void Bomba(){
		Vector3 nearest = transform.position;// + transform.forward;
		Vector3 tpos = new Vector3(Mathf.FloorToInt(nearest.x), 0, Mathf.FloorToInt(nearest.z));
		GameObject newMina = Instantiate(mina, tpos + new Vector3(.5f,0f,.5f), Quaternion.identity) as GameObject;
		newMina.GetComponent<Mina>().playerId = controller.playerId;
	}

}
