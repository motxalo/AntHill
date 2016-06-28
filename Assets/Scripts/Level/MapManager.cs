using UnityEngine;
using System.Collections;

public static class MapManager  {

	static int[,] map;
	//static GameObject[,] objects;
	static int[,] players;
	static Vector2 bounds = Vector2.zero;
	public static void Init(int xlength, int ylength){
		map = new int[xlength,ylength];
		bounds.x = xlength;
		bounds.y = ylength;
		//objects = new GameObject[xlength,ylength];
		for (int i=0; i<xlength;i++)
			for (int k=0; k<ylength;k++){
				map[i,k] = 0;
				//objects[i,k] = null;
			}
	}

	public static void SetTile(int _x, int _y, int _val){
		map[_x,_y] = _val;
	}

	public static int GetTile(int _x, int _y){
		if(_x < 0 || _y < 0 || _x >= bounds.x || _y >= bounds.y )
			return -1;
		return map[_x,_y] ;
	}

	public static void InitPlayers(int amount){
		players = new int[amount,3];
		for (int i = 0; i<amount; i++){
			players[i,0] = i;
			players[i,1] = 0;
			players[i,2] = 0;
		}
	}

	public static void PlayerIn(int _x, int _y, int _val){
		if(_x < 0 || _y < 0 || _x >= bounds.x || _y >= bounds.y ) return;
		if(players[_val, 1 ] != _x || players[_val,2] != _y){
			map[players[_val, 1], players[_val, 2]] = 0;
			players[_val,1] = _x;
			players[_val,2] = _y;
			map[_x, _y] = 100 + _val;
		}
	}

	public static Vector2 GetPlayerPos(int playerId){
		return new Vector2(players[playerId,1],players[playerId,2]);
	}

	/*
	public static void SetBomb(int _x, int _y, GameObject _bomb){
		objects[_x,_y] = _bomb;
	}

	public static void ExplodeBomb(int _x, int _y, bool effect){
		if(_x <0 || _y<0) return;
		Debug.Log("BOMB EXPLOSION IN "+_x+","+_y+"  " +objects[_x,_y]);
		//return;
		if (objects[_x,_y] != null){
			if ( effect ) objects[_x,_y].GetComponent<Bomb>().Explode();//.SendMessage("Explode",SendMessageOptions.DontRequireReceiver);
			objects[_x,_y] = null;
		}	
	}*/

}
