using UnityEngine;
using System.Collections;

public static class LevelEditorManager  {

	static int[,] map;

	public static void Init(int xlength, int ylength){
		map = new int[xlength,ylength];
		for (int i=0; i<xlength;i++)
			for (int k=0; k<ylength;k++){
				map[i,k] = 0;
			}
	}

	public static void SetTile(int _x, int _y, int _val){
		Debug.Log("TILE SET : "+_x+","+_y+" WITH VAL : "+_val);
		map[_x,_y] = _val;
	}

	public static void SaveToXML(){
		
	}

}
