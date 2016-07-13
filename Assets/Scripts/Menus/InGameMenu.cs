using UnityEngine;
using System.Collections;

public class InGameMenu : MonoBehaviour {

	public struct StatLine{
		public UnityEngine.UI.Text stName;
		public UnityEngine.UI.Text stDeaths;
		public UnityEngine.UI.Text stKills;
	}

	public StatLine[] statLines;

	// Use this for initialization
	void Start () {
		CreateScorer();
		HideMenu();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P))
			ShowMenu();
	}

	public void ShowMenu(){
		ShowStats();
		GetComponent<Canvas>().enabled = true;
		Time.timeScale = 0f;
	}

	public void HideMenu(){
		GetComponent<Canvas>().enabled = false;
		Time.timeScale = 1f;
	}

	public void ExitToMenu(){
		Application.LoadLevel(0);
	}

	void CreateScorer(){
		StatLine startingStatLine = new StatLine();
		startingStatLine.stName 	= transform.GetChild(3).GetComponent<UnityEngine.UI.Text>();
		startingStatLine.stKills 	= transform.GetChild(4).GetComponent<UnityEngine.UI.Text>();
		startingStatLine.stDeaths	= transform.GetChild(5).GetComponent<UnityEngine.UI.Text>();
		int playersAmount = PlayerPrefs.GetInt("Players");
		statLines = new StatLine[playersAmount];
		for (int i=0; i<playersAmount; i++){
			statLines[i].stName = Instantiate(startingStatLine.stName) as UnityEngine.UI.Text;
			statLines[i].stKills = Instantiate(startingStatLine.stKills) as UnityEngine.UI.Text;
			statLines[i].stDeaths = Instantiate(startingStatLine.stDeaths) as UnityEngine.UI.Text;
			statLines[i].stName.transform.parent = transform;
			statLines[i].stDeaths.transform.parent = transform;
			statLines[i].stKills.transform.parent = transform;
			statLines[i].stName.rectTransform.position   = startingStatLine.stName.rectTransform.position - new Vector3(0f, 50f*(i+1), 0f);
			statLines[i].stKills.rectTransform.position  = startingStatLine.stKills.rectTransform.position - new Vector3(0f, 50f*(i+1), 0f);
			statLines[i].stDeaths.rectTransform.position = startingStatLine.stDeaths.rectTransform.position - new Vector3(0f, 50f*(i+1), 0f);
		}
	}

	void ShowStats(){
		for (int i=0; i<statLines.Length; i++){
			statLines[i].stName.text = "Player "+(i+1);
			statLines[i].stKills.text = ""+StatManager.points[i];
			statLines[i].stDeaths.text = ""+StatManager.deaths[i];
		}
	}
}
