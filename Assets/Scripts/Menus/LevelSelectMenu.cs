using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Linq;

public class LevelSelectMenu : MonoBehaviour {

	public TextAsset 	LevelXML;
	public GameObject 	buttonGen;
	private int sep = 0;
	// Use this for initialization
	void Start () {
		DoLoading();
	}

	// Use this for initialization
	public void DoLoading () {

		TextAsset xmlSourceAsset = null;

		XDocument xmlDoc = null;

		xmlSourceAsset = LevelXML;
		if (xmlSourceAsset != null) {
			xmlDoc = XDocument.Parse (xmlSourceAsset.text);
			foreach(XElement tile in xmlDoc.Descendants("map"))
			{
				bool mapOk  = (1==int.Parse(""+tile.Attribute("p"+PlayerPrefs.GetInt("Players")).Value));
				if (mapOk){
					GameObject go;
					if(sep==0)
						go = buttonGen;
					else
						go = Instantiate(buttonGen) as GameObject;
					go.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = ""+tile.Attribute("name").Value;
					go.transform.parent = transform;
					go.GetComponent<RectTransform>().localPosition = new Vector3(0f, 450f - 75f * sep, 0f);
					go.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
					sep++;
				}
			}
		}
		if(sep ==0 )
			Destroy(buttonGen);
	}

	public void StartLevel(UnityEngine.UI.Text _text){
		PlayerPrefs.SetString("MAPNAME",_text.text);
		Application.LoadLevel(2);
		
	}

	public void BackToMenu(){
		Application.LoadLevel(0);
	}
}
