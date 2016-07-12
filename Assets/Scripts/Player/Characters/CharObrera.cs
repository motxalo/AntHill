using UnityEngine;
using System.Collections;

public class CharObrera : MonoBehaviour {

	private PlayerController controller;
	public GameObject casilla;
	public float timeToRestore = 5f;

	// Use this for initialization
	void Start () {
		controller = GetComponent<PlayerController>();
	}

	// Update is called once per frame
	void Update () {

	}

	public void DoSpecialAttack(){
		Build();
	}	

	public void RestoreSpecialAttack(){
		controller.canSpecial = true;
	}	

	void Build(){
		Vector3 nearest = transform.position + transform.forward;
		Vector3 tpos = new Vector3(Mathf.FloorToInt(nearest.x), 0f , Mathf.FloorToInt(nearest.z));
		if(MapManager.GetTile(Mathf.FloorToInt(nearest.x),Mathf.FloorToInt(nearest.z)) == 0){
			GameObject newCasilla = Instantiate(casilla, tpos + new Vector3(.5f,0f,.5f), Quaternion.identity) as GameObject;
			newCasilla.name = "Tile"+Mathf.FloorToInt(nearest.x)+"_"+Mathf.FloorToInt(nearest.z);
			controller.canSpecial = false;
			Invoke("RestoreSpecialAttack",timeToRestore);
			MapManager.SetTile(Mathf.FloorToInt(nearest.x),Mathf.FloorToInt(nearest.z),2);
		}
	}
}
