using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Linq;

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
				if(map[i,k])>200
					element2.SetAttribute ("category", ""0);
				else
					element2.SetAttribute ("category", ""+map[i,k]);
				element2.SetAttribute ("posx", ""+i);
				element2.SetAttribute ("posy", ""+k);
			}

		docMap.Save( "map.xml" );
		//docMap.Save( Application.dataPath + "map.xml" );
		
		/************************************************/
		
		//salvar items		
		XmlDocument itemMap = new XmlDocument( );

		//(1) the xml declaration is recommended, but not mandatory
		XmlDeclaration xmlDeclaration = itemMap.CreateXmlDeclaration( "1.0", "UTF-8", null );
		XmlElement root = itemMap.DocumentElement;
		itemMap.InsertBefore( xmlDeclaration, root );

		//(2) string.Empty makes cleaner code
		XmlElement element1 = itemMap.CreateElement( string.Empty, "level", string.Empty );
		itemMap.AppendChild( element1 );

		for (int i = 0; i < 50; i++)
			for (int k = 0; k < 50; k++) {
				XmlElement element2 = itemMap.CreateElement (string.Empty, "tile", string.Empty);
				element1.AppendChild (element2);
				if(map[i,k])<200
					element2.SetAttribute ("category", ""0);
				else
					element2.SetAttribute ("category", ""+map[i,k]);
				element2.SetAttribute ("posx", ""+i);
				element2.SetAttribute ("posy", ""+k);
			}

		itemMap.Save( "item.xml" );
		//docMap.Save( Application.dataPath + "map.xml" );
	}

}
