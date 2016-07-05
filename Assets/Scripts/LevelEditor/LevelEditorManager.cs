using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

public static class LevelEditorManager  {

	static int[,] map;

	static Dictionary<int,Texture> textureSet;

    static GameObject botones;

	public static void Init(int xlength, int ylength){

        botones = GameObject.Find("Buttons");

		TextAsset xmlSourceAsset = null;
		XDocument xmlDoc = null;
		Debug.Log("CARGANDO MAPA : /EditorMaps/mapa" );
		xmlSourceAsset = Resources.Load("EditorMaps/mapa") as TextAsset;

		if (xmlSourceAsset != null) {
			map = new int[xlength,ylength];
			for (int i=0; i<xlength;i++)
				for (int k=0; k<ylength;k++){
					map[i,k] = 0;
				}
			
			xmlDoc = XDocument.Parse (xmlSourceAsset.text);
			foreach (XElement tile in xmlDoc.Descendants("tile")) {
				int x = int.Parse ("" + tile.Attribute ("posx").Value);
				int y = int.Parse ("" + tile.Attribute ("posy").Value);
				int value = int.Parse ("" + tile.Attribute ("category").Value);
				SetTile (x, y, value);
			}
		}

		Debug.Log("CARGANDO OBJETOS : /EditorMaps/objetos" );
		xmlSourceAsset = Resources.Load("EditorMaps/objetos") as TextAsset;

		if (xmlSourceAsset != null) {

			xmlDoc = XDocument.Parse (xmlSourceAsset.text);
			foreach (XElement tile in xmlDoc.Descendants("tile")) {

				int value = int.Parse ("" + tile.Attribute ("category").Value);
				if(value != 0){
					int x = int.Parse ("" + tile.Attribute ("posx").Value);
					int y = int.Parse ("" + tile.Attribute ("posy").Value);
					SetTile (x, y, value);
				}
			}
		}
		Debug.Log (map);
	}

	public static void SetTile(int _x, int _y, int _val){
//		Debug.Log("TILE SET : "+_x+","+_y+" WITH VAL : "+_val);
		map[_x,_y] = _val;
	}

	public static int GetTile(int _x, int _y){
		//		Debug.Log("TILE SET : "+_x+","+_y+" WITH VAL : "+_val);
		return map[_x,_y];
	}

	// DICTIONARY SETS

	public static void AddTexture(int _id, Texture _tex){
		if(textureSet == null) textureSet = new Dictionary<int, Texture>();
		textureSet.Add(_id,_tex);
	}

	public static Texture GetTexture(int _id){
		return textureSet[_id];
	}

	public static void SaveToXML(){
		
		//salvar mapa		
		XmlDocument docMap = new XmlDocument( );

		//(1) the xml declaration is recommended, but not mandatory
		XmlDeclaration xmlDeclaration = docMap.CreateXmlDeclaration( "1.0", "UTF-8", null );
		XmlElement root = docMap.DocumentElement;
		docMap.InsertBefore( xmlDeclaration, root );

		//(2) string.Empty makes cleaner code
		XmlElement element1 = docMap.CreateElement( string.Empty, "level", string.Empty );
		docMap.AppendChild( element1 );

		for (int i = 0; i < 50; i++)
			for (int k = 0; k < 50; k++) {
				XmlElement element2 = docMap.CreateElement (string.Empty, "tile", string.Empty);
				element1.AppendChild (element2);
				if(map[i,k]>=200)
					element2.SetAttribute ("category", "0");
				else
					element2.SetAttribute ("category", ""+map[i,k]);
				element2.SetAttribute ("posx", ""+i);
				element2.SetAttribute ("posy", ""+k);
			}

		docMap.Save (Application.dataPath + "/Resources/EditorMaps/mapa.xml");
		Debug.Log ("mapa salvado");

		//docMap.Save( Application.dataPath + "map.xml" );
		
		/************************************************/
		
		//salvar items		
		XmlDocument itemMap = new XmlDocument( );

		//(1) the xml declaration is recommended, but not mandatory
		xmlDeclaration = itemMap.CreateXmlDeclaration( "1.0", "UTF-8", null );
		root = itemMap.DocumentElement;
		itemMap.InsertBefore( xmlDeclaration, root );

		//(2) string.Empty makes cleaner code
		element1 = itemMap.CreateElement( string.Empty, "level", string.Empty );
		itemMap.AppendChild( element1 );

		for (int i = 0; i < 50; i++)
			for (int k = 0; k < 50; k++) {
				XmlElement element2 = itemMap.CreateElement (string.Empty, "tile", string.Empty);
				element1.AppendChild (element2);
				if(map[i,k]<200)
					element2.SetAttribute ("category", "0");
				else
					element2.SetAttribute ("category", ""+map[i,k]);
				element2.SetAttribute ("posx", ""+i);
				element2.SetAttribute ("posy", ""+k);
			}

		itemMap.Save (Application.dataPath + "/Resources/EditorMaps/objetos.xml");
		Debug.Log ("items salvados");
		//docMap.Save( Application.dataPath + "map.xml" );
	}

    public static void tabHide() {
        if (botones.transform.position == new Vector3(5, 0, -5))
            botones.transform.position = new Vector3(20,0,-5);
        else
            botones.transform.position = new Vector3(5, 0, -5);
    }

}
