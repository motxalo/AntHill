using UnityEngine;
using System.Collections;

public class Mina : MonoBehaviour {


	public int playerId = -1;
	public Vector2 cell;
	public int alcance = 3;
	public GameObject effect;
	// Use this for initialization
	void Start () {
		cell = new Vector2(Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.z));
		Invoke("RemoveRenderer",2f);
	}

	void RemoveRenderer(){
		GetComponent<MeshRenderer>().enabled = false;
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
		if(CanExplode(transform.position))
			Instantiate(effect, transform.position, transform.rotation);
		Destroy (gameObject);
		return;
	}

	void DelayedExplode(){
		Debug.Log("CHAINED EXPLOSION : "+gameObject.name);
		CancelInvoke("Explode");
		Invoke("Explode",.1f);
	}

	bool CanExplode (Vector3 pos){
		int tile = MapManager.GetTile(Mathf.FloorToInt(pos.x), Mathf.FloorToInt(pos.z));
		foreach (Bomb _b in FindObjectsOfType<Bomb>())
			if(Mathf.FloorToInt(pos.x) == _b.cell.x && Mathf.FloorToInt(pos.z) == _b.cell.y){
				_b.DelayedExplode();
				_b.playerId = playerId;
			}
		if(tile >= 100 ){
			GameObject.Find("Player"+(tile-100)).SendMessage("Die",playerId);
			tile = 0;
		}
		if(tile == 2){
			GameObject.Find("Tile"+Mathf.FloorToInt(pos.x)+"_"+Mathf.FloorToInt(pos.z)).SendMessage("Die");
			tile = 0;
		}
		return ( tile == 0);
	}

	public void PlayerEnter(PlayerController _player){
		if(playerId== _player.playerId && playerId != -1)
			return;
		_player.SendMessage("Die");
		Explode();
	}

}
