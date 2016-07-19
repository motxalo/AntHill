using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour {

	public UnityEngine.UI.Image image;
	private int status = 0; // 1 = fadein 2 = fadeout
	private float speed = 1f;
	private Color tColor;
	private float maxAlpha = 1f;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
		image = transform.GetChild(0).GetComponent<UnityEngine.UI.Image>();
		tColor = image.color;
		FadeIn(5f);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.A)) FadeIn(1f);
		if(Input.GetKeyDown(KeyCode.S)) FadeOut(1f);
		if( status == 1 ) {
			if(image.color.a <= 0f) StopFade();
			//tColor.a= Mathf.Lerp(tColor.a,0f, speed * Time.deltaTime);
			tColor.a -= speed * Time.deltaTime;
			image.color  = tColor;
		}

		if( status == 2 ) {
			if(image.color.a >= maxAlpha) StopFade();
			//tColor.a = Mathf.Lerp(tColor.a,maxAlpha, speed * Time.deltaTime);
			tColor.a += speed * Time.deltaTime;
			image.color  = tColor;
		}
	}

	public void FadeOut(float time){
		Debug.Log("FADE OUT ");
		status = 2;
		speed = maxAlpha / time;
		tColor.a = 0f;
	}

	public void FadeIn(float time){
		Debug.Log("FADE IN ");
		status = 1;
		speed = maxAlpha / time;
		tColor.a = maxAlpha;
	}

	public void StopFade(){
		Debug.Log("FADE STOP ");
		status = 0;
	}
}
