using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	public Vector2 cell;
	public float speed = 3f;
	public int alcance = 3;
	public GameObject effect;
	// Use this for initialization
	void Start () {
		cell = new Vector2(Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.z));
		//MapManager.SetBomb(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.z),gameObject);
		Invoke("Explode",speed);
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Renderer>().material.color = Color.Lerp(GetComponent<Renderer>().material.color,Color.red, Time.deltaTime / speed);
	}

	public void Explode(){
		for(int i=1; i<= alcance; i++){
			if(CanExplode (transform.position + new Vector3(1,0,0)*i))
				Instantiate(effect, transform.position + new Vector3(1,0,0)*i, transform.rotation);
			else 
				break;
		}
		for(int i=1; i<= alcance; i++){
			if(CanExplode (transform.position + new Vector3(-1,0,0)*i))
				Instantiate(effect, transform.position + new Vector3(-1,0,0)*i, transform.rotation);
			else 
				break;
		}
		for(int i=1; i<= alcance; i++){
			if(CanExplode (transform.position + new Vector3(0,0,1)*i))
				Instantiate(effect, transform.position + new Vector3(0,0,1)*i, transform.rotation);
			else 
				break;
		}
		for(int i=1; i<= alcance; i++){
			if(CanExplode (transform.position + new Vector3(0,0,-1)*i))
				Instantiate(effect, transform.position + new Vector3(0,0,-1)*i, transform.rotation);
			else 
				break;
		}
		//MapManager.ExplodeBomb(cell.x, cell.y, false);
		if(CanExplode(transform.position))
			Instantiate(effect, transform.position, transform.rotation);
		Destroy (gameObject);
		return;
		for(int i=1; i<= alcance; i++){
			//PROCESAR CANVAS
			if(CanExplode (transform.position + new Vector3(1,0,0)*i))
				Instantiate(effect, transform.position + new Vector3(1,0,0)*i, transform.rotation);
			if(CanExplode(transform.position + new Vector3(-1,0,0)*i))
				Instantiate(effect, transform.position + new Vector3(-1,0,0)*i, transform.rotation);
			if(CanExplode(transform.position + new Vector3(0,0,1)*i))
				Instantiate(effect, transform.position + new Vector3(0,0,1)*i, transform.rotation);
			if(CanExplode(transform.position + new Vector3(0,0,-1)*i))
				Instantiate(effect, transform.position + new Vector3(0,0,-1)*i, transform.rotation);
		}

		Instantiate(effect, transform.position, transform.rotation);

		Destroy (gameObject);
	}

	void DelayedExplode(){
		Debug.Log("CHAINED EXPLOSION : "+gameObject.name);
		CancelInvoke("Explode");
		Invoke("Explode",.1f);
	}

	bool CanExplode (Vector3 pos){
		int tile = MapManager.GetTile(Mathf.FloorToInt(pos.x), Mathf.FloorToInt(pos.z));
		//MapManager.ExplodeBomb(Mathf.FloorToInt(pos.x), Mathf.FloorToInt(pos.z), true);
		foreach (Bomb _b in FindObjectsOfType<Bomb>())
			if(Mathf.FloorToInt(pos.x) == _b.cell.x && Mathf.FloorToInt(pos.z) == _b.cell.y)
				_b.DelayedExplode();
		if(tile >= 100 ){
			GameObject.Find("Player"+(tile-100)).SendMessage("Die");
			tile = 0;
		}
		if(tile == 2){
			GameObject.Find("Tile"+Mathf.FloorToInt(pos.x)+"_"+Mathf.FloorToInt(pos.z)).SendMessage("Die");
			tile = 0;
		}
		return ( tile == 0);
	}
}
