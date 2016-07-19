using UnityEngine;
using System.Collections;

public class CharSelectMenu : MonoBehaviour {

	public UnityEngine.UI.Image[] players;
	public int lineAmount = 3;
	public int maxLines = 0;
	private int playersAmount ;

	public UnityEngine.UI.Image[] playerSelectors;
	private int[] playerSelPos;
	public bool[] ready;
	private CharSelectCanvas[] canvases;

	public CharSelectorIdent tident;

	// Use this for initialization
	void Start () {
		playersAmount = PlayerPrefs.GetInt("Players");
		Organize();
		times = new float[playersAmount];
		playerSelPos = new int[playersAmount];
		canvases = new CharSelectCanvas[playersAmount];
		ready = new bool[playersAmount];
		for ( int i=0; i< playersAmount;i++){
			times[i] = 0f;
			playerSelPos[i] = 0;
			ready[i] = false;
			canvases[i] = 	GameObject.Find("CanvasSelP"+(i+1)).GetComponent<CharSelectCanvas>();
			canvases[i].SetText(tident);
		}
		for (int i=playersAmount; i < playerSelectors.Length; i++){
			Destroy(playerSelectors[i].gameObject);
			Destroy(GameObject.Find("CanvasSelP"+(i+1)));
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i=0; i< playersAmount; i++)
			UpdateSelector(i);
		CheckReady();
	}

	void CheckReady(){
		for (int i=0; i< playersAmount; i++){
			if(ready[i] == false)
				return;
		}
		if(	PlayerPrefs.GetInt("GameMode") == 0)
			Application.LoadLevel(5);
		else
			Application.LoadLevel(4);
	}

	public Vector2 playerDisplacement = new Vector2(50f, 50f);

	void Organize(){
		Vector3 startPosition = players[0].rectTransform.position;
		for ( int i=0; i< players.Length; i++){
			Vector3 tDisp = new Vector3(playerDisplacement.x * (i % lineAmount), -1f * playerDisplacement.y * (i / lineAmount ),0);
			players[i].rectTransform.position = startPosition + tDisp ;
		}
		maxLines = players.Length;

	}

	private float[] times;
	private float slotTime = .5f;

	void UpdateSelector(int selectorId){
		bool upd = false;
		if(Input.GetButtonDown("CC"+selectorId)){
			ready[selectorId] = false;
			canvases[selectorId].DenySelection();
		}
		if(ready[selectorId]) return;
		times [selectorId] -= Time.deltaTime;
		if(times[selectorId] > 0f) return;
		if(Input.GetAxis("Vertical"+selectorId) > .1f && playerSelPos[selectorId] >= lineAmount){
			playerSelPos[selectorId] -= lineAmount;
			times [selectorId] = slotTime;
			upd = true;
		} 
		if(Input.GetAxis("Vertical"+selectorId) < -.1f && playerSelPos[selectorId] < (maxLines - lineAmount )){
			playerSelPos[selectorId] += lineAmount;
			times [selectorId] = slotTime;
			upd = true;
		} 
		if(Input.GetAxis("Horizontal"+selectorId) > .1f && playerSelPos[selectorId] < (maxLines-1)){
			playerSelPos[selectorId] += 1;
			times [selectorId] = slotTime;
			upd = true;
		} 
		if(Input.GetAxis("Horizontal"+selectorId) < -.1f && playerSelPos[selectorId] > 0){
			playerSelPos[selectorId] -= 1;
			times [selectorId] = slotTime;
			upd = true;
		}
		if(Input.GetButtonDown("Bomb"+selectorId)){
			PlayerPrefs.SetInt("Character"+selectorId,playerSelPos[selectorId]);
			ready[selectorId] = true;
			canvases[selectorId].ConfirmSelection();
		}
		if (upd){
			playerSelectors[selectorId].rectTransform.position = players[playerSelPos[selectorId]].rectTransform.position - new Vector3(0f,0f,1f);
			canvases[selectorId].SetText(players[playerSelPos[selectorId]].GetComponent<CharSelectorIdent>());
		}
	}

	public void BackToMenu(){
		Application.LoadLevel(2);
	}
}
