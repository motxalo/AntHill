using UnityEngine;
using System.Collections;

public static class MapManager  {

	static int[,] map;
	static int[,] players;

	public static void Init(int xlength, int ylength){
		map = new int[xlength,ylength];
		for (int i=0; i<xlength;i++)
			for (int k=0; k<ylength;k++)
				map[i,k] = 0;
	}

	public static void SetTile(int _x, int _y, int _val){
		map[_x,_y] = _val;
	}

	public static int GetTile(int _x, int _y){
		if(_x < 0 || _y < 0)
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
		if(_x <0 || _y<0) return;
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
		
}
