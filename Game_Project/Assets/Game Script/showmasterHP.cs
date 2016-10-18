using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class showmasterHP : MonoBehaviour {
	public static int masterHP;
	GameObject musicControll;
	GameObject eventSystem;
	public Text text;
	int playMusic;
	// Use this for initialization
	void Start () {
		playMusic = 1;
		musicControll = GameObject.Find ("MusicController");
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
			if (playMusic == 1) {
				musicControll.GetComponent<musicController> ().ChoiceOneShot (11);
				playMusic--;
			}
			StartCoroutine(eventSystem.GetComponent<victory> ().defeatBoard ());
		}
	}
}
