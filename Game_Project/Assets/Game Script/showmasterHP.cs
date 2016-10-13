using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class showmasterHP : MonoBehaviour {
	public static int masterHP;
	GameObject eventSystem;
	public Text text;
	// Use this for initialization
	void Start () {
		eventSystem = GameObject.FindGameObjectWithTag ("eventsystem");
		masterHP = 30;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "" + masterHP;
		StartCoroutine(checkHP ());
	}

	public IEnumerator checkHP (){
		if (masterHP <= 0) {
			//可能需要輸掉遊戲的動畫或音效
			yield return new WaitForSeconds (1);
			StartCoroutine(eventSystem.GetComponent<victory> ().defeatBoard ());
		}
	}
}
