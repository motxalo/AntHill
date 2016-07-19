using UnityEngine;
using System.Collections;

public static class StatManager  {

	public static int[] team; // Cada jugador a q equipo pertenece.
	public static int[] points; // Cada jugador los puntos.
	public static int[] deaths; // Cada jugador las veces q muere.

	public static void InitStats(int _players){
		team = new int[_players];
		points = new int[_players];
		deaths = new int[_players];
		for (int i=0; i<_players; i++){
			team[i] = -1;
			points[i] = 0;
			deaths[i] = 0;
		}
	}
		
	public static void SetTeam(int _player, int _team){
		team[_player] = _team;
	}

	public static void AddPoint(int killer, int dead, int value){
		if(killer >= 0) points[killer] += value;
		if(dead >= 0) 	deaths[dead] += value;
	}
}
