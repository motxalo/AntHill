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
		XmlDocument doc = new XmlDocument( );

		//(1) the xml declaration is recommended, but not mandatory
		XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration( "1.0", "UTF-8", null );
		XmlElement root = doc.DocumentElement;
		doc.InsertBefore( xmlDeclaration, root );

		//(2) string.Empty makes cleaner code
		XmlElement element1 = doc.CreateElement( string.Empty, "level", string.Empty );
		doc.AppendChild( element1 );

		for (int i = 0; i < 50; i++)
			for (int k = 0; k < 50; k++) {
				XmlElement element2 = doc.CreateElement (string.Empty, "tile", string.Empty);
				element1.AppendChild (element2);

				element2.SetAttribute ("category", ""+map[i,k]);
				element2.SetAttribute ("posx", ""+i);
				element2.SetAttribute ("posy", ""+k);
			}
		/*
		XmlElement element3 = doc.CreateElement( string.Empty, "level2", string.Empty );
		XmlText text1 = doc.CreateTextNode( "text" );
		element3.AppendChild( text1 );
		element2.AppendChild( element3 );

		XmlElement element4 = doc.CreateElement( string.Empty, "level2", string.Empty );
		XmlText text2 = doc.CreateTextNode( "other text" );
		element4.AppendChild( text2 );
		element2.AppendChild( element4 );
		*/
		doc.Save( "doc.xml" );
		//doc.Save( Application.dataPath + "doc.xml" );
	}

}
