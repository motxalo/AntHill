using UnityEngine;
using System.Collections;

public class LevelEditorTab : MonoBehaviour {

    public bool hide = false;
    public Vector3 target;
    public float speed = 0.5f;
    public GameObject menu;
    GameObject other;


    // Use this for initialization
    void Start () {
        if (hide)
        {
            target = new Vector3(-35, -30, 10);
        }
        else
        {
            target = new Vector3(-55, -30, 10);
        }
    }
	
	// Update is called once per frame
	void Update () {
        menu.transform.localPosition = Vector3.Lerp(menu.transform.localPosition, target, speed);
    }

    public void DoClicked()
    {
        other=GameObject.Find("Tabs").GetComponent<LevelEditorTabsManager>().currentTab;
        if (hide)
        {
            hide = false;
            target = new Vector3(-55, -30, 10);
            other.transform.GetComponent<LevelEditorTab>().hide = true;
            other.transform.GetComponent<LevelEditorTab>().target = new Vector3(-35, -30, 10);
            GameObject.Find("Tabs").GetComponent<LevelEditorTabsManager>().currentTab = gameObject;
        }
        else
        {
            hide = true;
            target = new Vector3(-35, -30, 10);
        }                    
    }
}
