using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class sceneFade : MonoBehaviour {
	public Texture fadeImage;
	public Color fadeColor = Color.black;
	public float fadeInSpeed = 0.01f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.color = this.fadeColor;
		if (this.fadeImage)
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), this.fadeImage);
	}

	public IEnumerator FadeIn(){
		Debug.Log ("進入FadeIn");
		while (this.fadeColor.a > 0) {
			Debug.Log ("fadeColor.a is :" + this.fadeColor.a);
			this.fadeColor.a -= Time.deltaTime * this.fadeInSpeed*0.5f;
			yield return null;
		}

		this.fadeColor.a = 0;
	}

	public IEnumerator FadeOut(){
		Debug.Log ("進入FadeOut");
		while (this.fadeColor.a < 0.9) {
			this.fadeColor.a += Time.deltaTime * this.fadeInSpeed*0.8f;
			yield return null;
		}
		this.fadeColor.a = 1;
	}
}
