using UnityEngine;
using System.Collections;

public class CharSelectCanvas : MonoBehaviour {

	UnityEngine.UI.Text tName;
	UnityEngine.UI.Text tSpeed;
	UnityEngine.UI.Text tCool;
	UnityEngine.UI.Text tSpecial;
	UnityEngine.UI.Text tDescription;
	UnityEngine.UI.Text playerId;

	// Use this for initialization
	void Start () {
		playerId 	= transform.GetChild(0).GetComponent<UnityEngine.UI.Text>();
		tName 		= transform.GetChild(1).GetComponent<UnityEngine.UI.Text>();
		tSpeed 		= transform.GetChild(2).GetComponent<UnityEngine.UI.Text>();
		tCool 		= transform.GetChild(3).GetComponent<UnityEngine.UI.Text>();
		tSpecial 	= transform.GetChild(4).GetComponent<UnityEngine.UI.Text>();
	}
	
	public void SetText( CharSelectorIdent ident){
		tName.text = ident.selectorName;
		tSpeed.text = "speed : "+ident.speed+" m/s";
		tCool.text = "cooldown : "+ident.coolTime+" seg";
		tSpecial.text = ident.specialPower;
	}

	public void ConfirmSelection(){
		playerId.color = Color.yellow;
		tName.color = Color.yellow;
		tSpeed.color = Color.yellow;
		tCool.color = Color.yellow;
		tSpecial.color = Color.yellow;
	}

	public void DenySelection(){
		playerId.color = Color.white;
		tName.color = Color.white;
		tSpeed.color = Color.white;
		tCool.color = Color.white;
		tSpecial.color = Color.white;
	}
}
