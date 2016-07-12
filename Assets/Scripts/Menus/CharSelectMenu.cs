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

	// Use this for initialization
	void Start () {
		playersAmount = PlayerPrefs.GetInt("Players");
		Organize();
		times = new float[playersAmount];
		playerSelPos = new int[playersAmount];
		ready = new bool[playersAmount];
		for ( int i=0; i< playersAmount;i++){
			times[i] = 0f;
			playerSelPos[i] = 0;
			ready[i] = false;
		}
		for (int i=playersAmount; i < playerSelectors.Length; i++)
			Destroy(playerSelectors[i].gameObject);
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
		if(Input.GetButtonDown("CC"+selectorId)){
			ready[selectorId] = false;
		}
		if(ready[selectorId]) return;
		times [selectorId] -= Time.deltaTime;
		if(times[selectorId] > 0f) return;
		if(Input.GetAxis("Vertical"+selectorId) > .1f && playerSelPos[selectorId] >= lineAmount){
			playerSelPos[selectorId] -= lineAmount;
			times [selectorId] = slotTime;
		} 
		if(Input.GetAxis("Vertical"+selectorId) < -.1f && playerSelPos[selectorId] < (maxLines - lineAmount )){
			playerSelPos[selectorId] += lineAmount;
			times [selectorId] = slotTime;
		} 
		if(Input.GetAxis("Horizontal"+selectorId) > .1f && playerSelPos[selectorId] < (maxLines-1)){
			playerSelPos[selectorId] += 1;
			times [selectorId] = slotTime;
		} 
		if(Input.GetAxis("Horizontal"+selectorId) < -.1f && playerSelPos[selectorId] > 0){
			playerSelPos[selectorId] -= 1;
			times [selectorId] = slotTime;
		}
		if(Input.GetButtonDown("Bomb"+selectorId)){
			PlayerPrefs.SetInt("Character"+selectorId,playerSelPos[selectorId]);
			ready[selectorId] = true;
		}
		playerSelectors[selectorId].rectTransform.position = players[playerSelPos[selectorId]].rectTransform.position - new Vector3(0f,0f,1f);
	}

	public void BackToMenu(){
		Application.LoadLevel(2);
	}
}
