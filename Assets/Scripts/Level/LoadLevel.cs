using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Linq;

public class LoadLevel : MonoBehaviour {

	public GameObject tilePrefab;
	public GameObject[] objectsPrefab;
	public GameObject[] storyObjectsPrefab;
	public Material material;
	public Material breakable;

	public int size = 50;

	// Use this for initialization
	public void DoLoading () {
		Vector3 tempPos = transform.position;

		TextAsset xmlSourceAsset = null;

		XDocument xmlDoc = null;
		Debug.Log("CARGANDO MAPA : "+"Maps/"+PlayerPrefs.GetString("MAPNAME")+"/mapa");
		xmlSourceAsset = Resources.Load("Maps/"+PlayerPrefs.GetString("MAPNAME")+"/mapa") as TextAsset;
		// ESTO FUNCIONA SI TODO ESTA ESCALA 1.1
		MapManager.InitPlayers(4);
		MapManager.Init(size,size);
		if (xmlSourceAsset != null) {
			xmlDoc = XDocument.Parse (xmlSourceAsset.text);
			foreach(XElement tile in xmlDoc.Descendants("tile"))
			{
				//Debug.Log ("CREATED TILE : "+ tile.Attribute("posx").Value+","+tile.Attribute("posy").Value);
				int x = int.Parse(""+tile.Attribute("posx").Value);
				int y = int.Parse(""+tile.Attribute("posy").Value);

				// AQUI HARIAMOS LA DIFERENCIACION ENTRE TILES DIFERENTES
				int value = int.Parse(""+tile.Attribute("category").Value);
				MapManager.SetTile(x,y,value);
				if(value != 0){
					if (value >= 100){
						MapManager.PlayerIn(x,y,value-100);
					}else{
						
						GameObject cube = Instantiate(tilePrefab,tempPos + new Vector3(x, 0, y), Quaternion.identity) as GameObject;
						cube.transform.position += cube.transform.localScale/2f;
						if(value == 1)
							cube.GetComponent<MeshRenderer> ().material = material;
						else
							cube.GetComponent<MeshRenderer> ().material = breakable;
						cube.transform.parent = gameObject.transform;
						cube.name ="Tile"+x+"_"+y;
					}
				}
			}
		}
		// CArgo los objetos
		//Debug.Log("CARGANDO OBJETOS : "+"Maps/"+PlayerPrefs.GetString("MAPNAME")+"/objetos");
		xmlSourceAsset = Resources.Load("Maps/"+PlayerPrefs.GetString("MAPNAME")+"/objetos") as TextAsset;
		if (xmlSourceAsset != null) {
			xmlDoc = XDocument.Parse (xmlSourceAsset.text);
			foreach(XElement tile in xmlDoc.Descendants("tile"))
			{
				//Debug.Log ("CREATED TILE : "+ tile.Attribute("posx").Value+","+tile.Attribute("posy").Value);
				int x = int.Parse(""+tile.Attribute("posx").Value);
				int y = int.Parse(""+tile.Attribute("posy").Value);

				// AQUI HARIAMOS LA DIFERENCIACION ENTRE TILES DIFERENTES
				int value = int.Parse(""+tile.Attribute("category").Value);
				if(value>= 300){ // DEBUG XA TELEPORTS
					GameObject cube = Instantiate(storyObjectsPrefab[value-300],tempPos + new Vector3(x, 0, y), Quaternion.Euler(new Vector3(90f,0f,0f))) as GameObject;
					cube.transform.position += new Vector3(.5f,.5f,.5f);
					cube.transform.parent = gameObject.transform;
					cube.name ="Object"+x+"_"+y;
					cube.GetComponent<DoorTranslator>().destLevel = new Vector2(int.Parse(""+tile.Attribute("destx").Value),int.Parse(""+tile.Attribute("desty").Value));
					cube.SendMessage("SetID",value,SendMessageOptions.DontRequireReceiver);
				}
				else if (value>= 200){
					GameObject cube = Instantiate(objectsPrefab[value-200],tempPos + new Vector3(x, 0, y), Quaternion.Euler(new Vector3(90f,0f,0f))) as GameObject;
					cube.transform.position += new Vector3(.5f,.5f,.5f);
					cube.transform.parent = gameObject.transform;
					cube.name ="Object"+x+"_"+y;
					cube.SendMessage("SetID",value,SendMessageOptions.DontRequireReceiver);
				}

			}
		}
		// Debug para el borde
		for(int i = 0; i<size;i++){
			GameObject cube = Instantiate(tilePrefab,tempPos + new Vector3(0, 0, i), Quaternion.identity) as GameObject;
			cube.transform.position+=cube.transform.localScale/2f;
			cube.transform.parent = gameObject.transform;
			cube.GetComponent<MeshRenderer> ().material = material;
			cube = Instantiate(tilePrefab,tempPos + new Vector3(size-1, 0, i), Quaternion.identity) as GameObject;
			cube.transform.position+=cube.transform.localScale/2f;
			cube.transform.parent = gameObject.transform;
			cube.GetComponent<MeshRenderer> ().material = material;
			cube = Instantiate(tilePrefab,tempPos + new Vector3(i, 0, 0), Quaternion.identity) as GameObject;
			cube.transform.position+=cube.transform.localScale/2f;
			cube.transform.parent = gameObject.transform;
			cube.GetComponent<MeshRenderer> ().material = material;
			cube = Instantiate(tilePrefab,tempPos + new Vector3(i, 0, size-1), Quaternion.identity) as GameObject;
			cube.transform.position+=cube.transform.localScale/2f;
			cube.transform.parent = gameObject.transform;
			cube.GetComponent<MeshRenderer> ().material = material;
		}

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.O))
			DebugMap();
	}

	void DebugMap(){
		for(int i=0;i<size; i++){
			string tStr = "";
			for(int k=0; k< size; k++)
				tStr += (" "+MapManager.GetTile(k,i));
			Debug.Log(tStr);
		}
	}
}
